using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class LoginForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;
        private SqlDataReader _reader;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxPassword.Checked;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вийти з програми", "Підтвердити", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                SignIn();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void SignIn()
        {
            _command = new SqlCommand("SELECT * FROM Users WHERE user_name=@user_name AND password=@password", _connection);
            _command.Parameters.AddWithValue("@user_name", textBoxLogin.Text);
            _command.Parameters.AddWithValue("@password", textBoxPassword.Text);
            _connection.Open();
            _reader = _command.ExecuteReader();
            _reader.Read();

            if (_reader.HasRows)
            {
                MessageBox.Show($"Вітаю, {_reader["full_name"]}", "Доступ надано", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var mainForm = new MainForm();

                if (textBoxLogin.Text != "admin")
                {
                    mainForm.btnStaff.Visible = false;
                    mainForm.labelStaff.Visible = false;
                }
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show($"Неправильне ім'я користувача та/або пароль", "Доступ надано", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _connection.Close();   
        }
    }
}
