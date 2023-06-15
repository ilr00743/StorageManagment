using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class ProductEditorForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;
        private SqlDataReader _reader;

        public ProductEditorForm()
        {
            InitializeComponent();
            txtPrice.Text = "0,00";
            LoadCategories();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void LoadCategories()
        {
            comboBoxCategory.Items.Clear();
            _command = new SqlCommand("SELECT name FROM Categories", _connection);

            _connection.Open();
            _reader = _command.ExecuteReader();

            while (_reader.Read())
            {
                comboBoxCategory.Items.Add(_reader[0].ToString());
            }

            _reader.Close();
            _connection.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Ви хочете зберегти цей товар?", "Збереження запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CreateProduct();

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

        private void CreateProduct()
        {
            _command = new SqlCommand("INSERT INTO Products(name,price,quantity,description,category) VALUES(@name,@price,@quantity,@description, @category)", _connection);

            _command.Parameters.AddWithValue("@name", txtProductName.Text);
            _command.Parameters.AddWithValue("@price", float.Parse(txtPrice.Text));
            _command.Parameters.AddWithValue("@quantity", Convert.ToInt32(numQuantity.Value.ToString()));
            _command.Parameters.AddWithValue("@description", txtDescription.Text);
            _command.Parameters.AddWithValue("@category", comboBoxCategory.Text);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Ви хочете оновити дані цього товару?", "Оновлення запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateProduct();

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

        private void UpdateProduct()
        {
            _command = new SqlCommand("UPDATE Products SET name=@name,price=@price,quantity=@quantity,description=@description,category=@category WHERE Id LIKE '" + labelProductId.Text + "'", _connection);

            _command.Parameters.AddWithValue("@name", txtProductName.Text);
            _command.Parameters.AddWithValue("@price", float.Parse(txtPrice.Text));
            _command.Parameters.AddWithValue("@quantity", Convert.ToInt32(numQuantity.Value.ToString()));
            _command.Parameters.AddWithValue("@description", txtDescription.Text);
            _command.Parameters.AddWithValue("@category", comboBoxCategory.Text);

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void ClearTextFields()
        {
            txtProductName.Clear();
            txtPrice.Clear();
            numQuantity.Value = 0;
            txtDescription.Clear();
            comboBoxCategory.Text = "";
        }
    }
}
