using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class CategoriesForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;
        private SqlDataReader _reader;

        public CategoriesForm()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var categoryEditor = new CategoryEditorForm();
            categoryEditor.btnSave.Enabled = true;
            categoryEditor.btnUpdate.Enabled = false;
            categoryEditor.ShowDialog();
            LoadCategories();
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dgvCategories.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                OpenEditor(e);
            }

            if (columnName == "Delete")
            {
                if (MessageBox.Show("Ви точно хочете видалити цей запис", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteCategory(e);
                }
            }

            LoadCategories();
        }

        private void OpenEditor(DataGridViewCellEventArgs e)
        {
            var categoryEditorForm = new CategoryEditorForm();
            categoryEditorForm.labelCategoryId.Text = dgvCategories.Rows[e.RowIndex].Cells[0].Value.ToString();
            categoryEditorForm.txtCategoryName.Text = dgvCategories.Rows[e.RowIndex].Cells[1].Value.ToString();

            categoryEditorForm.btnSave.Enabled = false;
            categoryEditorForm.btnUpdate.Enabled = true;
            categoryEditorForm.ShowDialog();
        }

        private void DeleteCategory(DataGridViewCellEventArgs e)
        {
            _connection.Open();
            _command = new SqlCommand("DELETE FROM Categories WHERE Id LIKE '" + dgvCategories.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", _connection);
            _command.ExecuteNonQuery();
            _connection.Close();
            MessageBox.Show("Запис було успішно видалено");
        }

        public void LoadCategories()
        {
            dgvCategories.Rows.Clear();
            _command = new SqlCommand("SELECT * FROM Categories", _connection);

            _connection.Open();
            _reader = _command.ExecuteReader();

            while (_reader.Read())
            {
                dgvCategories.Rows.Add(_reader[0].ToString(), _reader[1].ToString());
            }

            _reader.Close();
            _connection.Close();
        }
    }
}
