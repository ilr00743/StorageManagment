using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class OrderEditorForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;
        private SqlDataReader _reader;
        private int _quantity = 0;

        public OrderEditorForm()
        {
            InitializeComponent();
            LoadProducts();
            LoadCustomers();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void LoadCustomers()
        {
            dgvCustomers.Rows.Clear();
            _command = new SqlCommand("SELECT id,full_name FROM Customers WHERE CONCAT(Id,full_name) LIKE N'%"+searchCustomer.Text+ "%' OR CONCAT(Id,full_name) LIKE '%" + searchCustomer.Text+"%'", _connection);

            _connection.Open();
            _reader = _command.ExecuteReader();

            while (_reader.Read())
            {
                dgvCustomers.Rows.Add(_reader[0].ToString(), _reader[1].ToString());
            }

            _reader.Close();
            _connection.Close();
        }

        private void LoadProducts()
        {
            dgvProducts.Rows.Clear();
            _command = new SqlCommand("SELECT * FROM Products WHERE CONCAT(Id,name,price,quantity,description,category) LIKE N'%" + searchProduct.Text + "%' OR CONCAT(Id,name,price,quantity,description,category) LIKE '%" + searchProduct.Text + "%'", _connection);

            _connection.Open();
            _reader = _command.ExecuteReader();

            while (_reader.Read())
            {
                dgvProducts.Rows.Add(_reader[0].ToString(), _reader[1].ToString(), _reader[2].ToString(), _reader[3].ToString(), _reader[4].ToString(), _reader[5].ToString());
            }

            _reader.Close();
            _connection.Close();
        }

        private void searchCustomer_TextChanged(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void searchProduct_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            GetQuantity();

            if (Convert.ToInt32(numQuantity.Value) > _quantity)
            {
                MessageBox.Show("Недостатньо товару!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numQuantity.Value--;
                return;
            }
            
            if (Convert.ToInt32(numQuantity.Value) > 0)
            {
                float total = float.Parse(txtPrice.Text) * Convert.ToInt32(numQuantity.Value);
                txtTotal.Text = total.ToString();
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            
            txtCustomerId.Text = dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCustomerName.Text = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            
            bool isZeroQuantity = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString() == "0";
            if (isZeroQuantity) return;

            txtProductId.Text = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTotal.Text = (float.Parse(txtPrice.Text) * Convert.ToInt32(numQuantity.Value)).ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerId.Text == "")
                {
                    MessageBox.Show("Виберіть покупця!","Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtProductId.Text == "")
                {
                    MessageBox.Show("Виберіть товар!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Ви хочете оформити це замовлення?", "Збереження запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CreateOrder();

                    MessageBox.Show("Дані було успішно збережено");
                    UpdateQuantity();

                    LoadProducts();
                    ClearTextFields();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потрібно заповнити поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CreateOrder()
        {
            _command = new SqlCommand("INSERT INTO Orders(date,product_id,price,quantity,total,customer_id) VALUES(@date,@product_id,@price,@quantity,@total,@customer_id)", _connection);

            _command.Parameters.AddWithValue("@date", orderDate.Value);
            _command.Parameters.AddWithValue("@product_id", Convert.ToInt32(txtProductId.Text));
            _command.Parameters.AddWithValue("@price", float.Parse(txtPrice.Text));
            _command.Parameters.AddWithValue("@quantity", Convert.ToInt32(numQuantity.Value.ToString()));
            _command.Parameters.AddWithValue("@total", float.Parse(txtTotal.Text.ToString()));
            _command.Parameters.AddWithValue("@customer_id", Convert.ToInt32(txtCustomerId.Text.ToString()));

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void UpdateQuantity()
        {
            _command = new SqlCommand("UPDATE Products SET quantity=(quantity-@quantity) WHERE Id LIKE '" + txtProductId.Text + "'", _connection);
            _command.Parameters.AddWithValue("@quantity", Convert.ToInt32(numQuantity.Value.ToString()));
            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void GetQuantity()
        {
            _command = new SqlCommand("SELECT quantity FROM Products WHERE Id='"+txtProductId.Text+"'", _connection);

            _connection.Open();
            _reader = _command.ExecuteReader();

            while (_reader.Read())
            {
                _quantity = Convert.ToInt32(_reader[0].ToString());
            }

            _reader.Close();
            _connection.Close();
        }

        private void ClearTextFields()
        {
            txtCustomerId.Clear();
            txtProductId.Clear();
            txtTotal.Clear();
            numQuantity.Value = 1;
            txtPrice.Clear();
            txtCustomerName.Clear();
            txtProductName.Clear();
            orderDate.Value = DateTime.Now;
        }
    }
}
