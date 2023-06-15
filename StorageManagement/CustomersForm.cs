using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class CustomersForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;
        private SqlDataReader _reader;

        public CustomersForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var customerEditorForm = new CustomerEditorForm();
            customerEditorForm.btnSave.Enabled = true;
            customerEditorForm.btnUpdate.Enabled = false;
            customerEditorForm.ShowDialog();
            LoadCustomers();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dgvCustomers.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                OpenEditor(e);
            }

            if (columnName == "Delete")
            {
                if (MessageBox.Show("Ви точно хочете видалити цей запис", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteCustomer(e);
                }
            }

            LoadCustomers();
        }

        private void OpenEditor(DataGridViewCellEventArgs e)
        {
            var customerEditorForm = new CustomerEditorForm();
            customerEditorForm.labelCustomerId.Text = dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
            customerEditorForm.txtFullName.Text = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
            customerEditorForm.txtPhone.Text = dgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();

            customerEditorForm.btnSave.Enabled = false;
            customerEditorForm.btnUpdate.Enabled = true;
            customerEditorForm.ShowDialog();
        }

        private void DeleteCustomer(DataGridViewCellEventArgs e)
        {
            _connection.Open();
            _command = new SqlCommand("DELETE FROM Customers WHERE Id LIKE '" + dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", _connection);
            _command.ExecuteNonQuery();
            _connection.Close();
            MessageBox.Show("Запис було успішно видалено");
        }

        private void LoadCustomers()
        {
            dgvCustomers.Rows.Clear();
            _command = new SqlCommand("SELECT * FROM Customers", _connection);

            _connection.Open();
            _reader = _command.ExecuteReader();

            while (_reader.Read())
            {
                dgvCustomers.Rows.Add(_reader[0].ToString(), _reader[1].ToString(), _reader[2].ToString());
            }

            _reader.Close();
            _connection.Close();
        }
    }
}
