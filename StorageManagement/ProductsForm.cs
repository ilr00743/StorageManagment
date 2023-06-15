using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class ProductsForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;
        private SqlDataReader _reader;

        public ProductsForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var productEditorForm = new ProductEditorForm();
            productEditorForm.btnSave.Enabled = true;
            productEditorForm.btnUpdate.Enabled = false;
            productEditorForm.ShowDialog();
            LoadProducts();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dgvProducts.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                OpenEditor(e);
            }

            if (columnName == "Delete")
            {
                if (MessageBox.Show("Ви точно хочете видалити цей запис", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteProduct(e);
                }
            }

            LoadProducts();
        }

        private void DeleteProduct(DataGridViewCellEventArgs e)
        {
            _connection.Open();
            _command = new SqlCommand("DELETE FROM Products WHERE Id LIKE '" + dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", _connection);
            _command.ExecuteNonQuery();
            _connection.Close();
            MessageBox.Show("Запис було успішно видалено");
        }

        private void OpenEditor(DataGridViewCellEventArgs e)
        {
            var productEditorForm = new ProductEditorForm();
            productEditorForm.labelProductId.Text = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
            productEditorForm.txtProductName.Text = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
            productEditorForm.txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
            productEditorForm.numQuantity.Value = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString());
            productEditorForm.txtDescription.Text = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
            productEditorForm.comboBoxCategory.Text = dgvProducts.Rows[e.RowIndex].Cells[5].Value.ToString();

            productEditorForm.btnSave.Enabled = false;
            productEditorForm.btnUpdate.Enabled = true;
            productEditorForm.ShowDialog();
        }

        private void LoadProducts()
        {
            dgvProducts.Rows.Clear();
            _command = new SqlCommand("SELECT * FROM Products WHERE CONCAT(Id,name,price,quantity,description,category) LIKE N'%" + textSearch.Text + "%' OR CONCAT(Id,name,price,quantity,description,category) LIKE '%" + textSearch.Text + "%'", _connection);

            _connection.Open();
            _reader = _command.ExecuteReader();

            while (_reader.Read())
            {
                dgvProducts.Rows.Add(_reader[0].ToString(), _reader[1].ToString(), _reader[2].ToString(), _reader[3].ToString(), _reader[4].ToString(), _reader[5].ToString());
            }

            _reader.Close();
            _connection.Close();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
