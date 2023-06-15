using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class StaffForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;
        private SqlDataReader _reader;

        public StaffForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var staffEditorForm = new StaffEditorForm();
            staffEditorForm.btnSave.Enabled = true;
            staffEditorForm.btnUpdate.Enabled = false;
            staffEditorForm.ShowDialog();
            LoadUsers();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dgvUser.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                OpenEditor(e);
            }

            if (columnName == "Delete")
            {
                if (MessageBox.Show("Ви точно хочете видалити цей запис", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteStaff(e);
                    MessageBox.Show("Запис було успішно видалено");
                }
            }

            LoadUsers();
        }

        private void DeleteStaff(DataGridViewCellEventArgs e)
        {
            _connection.Open();
            _command = new SqlCommand("DELETE FROM Users WHERE user_name LIKE '" + dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", _connection);
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void OpenEditor(DataGridViewCellEventArgs e)
        {
            var staffEditorForm = new StaffEditorForm();
            staffEditorForm.txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
            staffEditorForm.txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
            staffEditorForm.txtPassword.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
            staffEditorForm.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

            staffEditorForm.btnSave.Enabled = false;
            staffEditorForm.btnUpdate.Enabled = true;
            staffEditorForm.txtUserName.Enabled = false;
            staffEditorForm.ShowDialog();
        }

        public void LoadUsers()
        {
            dgvUser.Rows.Clear();
            _command = new SqlCommand("SELECT * FROM Users", _connection);

            _connection.Open();
            _reader = _command.ExecuteReader();

            int counter = 0;
            while (_reader.Read())
            {
                counter++;
                dgvUser.Rows.Add(counter, _reader[1].ToString(), _reader[2].ToString(), _reader[3].ToString(), _reader[4].ToString());
            }

            _reader.Close();
            _connection.Close();
        }
    }
}
