using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class CategoryEditorForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;

        public CategoryEditorForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Ви хочете зберегти цю категорію?", "Збереження запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CreateCategory();

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

        private void CreateCategory()
        {
            _command = new SqlCommand("INSERT INTO Categories(name) VALUES(@name)", _connection);

            _command.Parameters.AddWithValue("@name", txtCategoryName.Text);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Ви хочете оновити дані цієї категорії?", "Оновлення запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateCategory();

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

        private void UpdateCategory()
        {
            _command = new SqlCommand("UPDATE Categories SET name=@name WHERE Id LIKE '" + labelCategoryId.Text + "'", _connection);

            _command.Parameters.AddWithValue("@name", txtCategoryName.Text);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ClearTextFields()
        {
            txtCategoryName.Clear();
        }
    }
}
