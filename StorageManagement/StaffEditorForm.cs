using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class StaffEditorForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;

        public StaffEditorForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Ви хочете зберегти цього користувача? Після цього буде неможливо змінити логін користувача","Збереження запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CreateStaff();

                    MessageBox.Show("Дані було успішно збережено");

                    ClearTextFields();
                    Dispose();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потрібно заповнити поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CreateStaff()
        {
            _command = new SqlCommand("INSERT INTO Users(full_name,user_name,password,phone) VALUES(@fullname,@username,@password,@phone)", _connection);

            _command.Parameters.AddWithValue("@fullname", txtFullName.Text);
            _command.Parameters.AddWithValue("@username", txtUserName.Text);
            _command.Parameters.AddWithValue("@password", txtPassword.Text);
            _command.Parameters.AddWithValue("@phone", txtPhone.Text);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Ви хочете оновити дані цього користувача?", "Оновлення запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateStaff();

                    MessageBox.Show("Дані було успішно оновлено");

                    ClearTextFields();
                    Dispose();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потрібно заповнити поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateStaff()
        {
            _command = new SqlCommand("UPDATE Users SET full_name=@fullname,password=@password,phone=@phone WHERE user_name LIKE '" + txtUserName.Text + "'", _connection);

            _command.Parameters.AddWithValue("@fullname", txtFullName.Text);
            _command.Parameters.AddWithValue("@password", txtPassword.Text);
            _command.Parameters.AddWithValue("@phone", txtPhone.Text);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void ClearTextFields()
        {
            txtFullName.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
        }
    }
}
