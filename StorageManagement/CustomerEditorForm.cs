using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class CustomerEditorForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;

        public CustomerEditorForm()
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
                if (MessageBox.Show("Ви хочете зберегти цього покупця?", "Збереження запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CreateCustomer();

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

        private void CreateCustomer()
        {
            _command = new SqlCommand("INSERT INTO Customers(full_name,phone) VALUES(@fullname,@phone)", _connection);

            _command.Parameters.AddWithValue("@fullname", txtFullName.Text);
            _command.Parameters.AddWithValue("@phone", txtPhone.Text);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Ви хочете оновити дані цього покупця?", "Оновлення запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateCustomer();

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

        private void UpdateCustomer()
        {
            _command = new SqlCommand("UPDATE Customers SET full_name=@fullname,phone=@phone WHERE Id LIKE '" + labelCustomerId.Text + "'", _connection);

            _command.Parameters.AddWithValue("@fullname", txtFullName.Text);
            _command.Parameters.AddWithValue("@phone", txtPhone.Text);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void ClearTextFields()
        {
            txtFullName.Clear();
            txtPhone.Clear();
        }
    }
}
