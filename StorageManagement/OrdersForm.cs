using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class OrdersForm : Form
    {
        private SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\dbStorage.mdf;Integrated Security=True");
        private SqlCommand _command;
        private SqlDataReader _reader;

        public OrdersForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            var orderEditorForm = new OrderEditorForm();
            orderEditorForm.ShowDialog();
            LoadOrders();
        }

        private void LoadOrders()
        {
            dgvOrders.Rows.Clear();
            _command = new SqlCommand("SELECT O.Id,date,P.Id,P.name,O.price,O.quantity,O.total,C.full_name FROM Orders AS O JOIN Customers AS C ON O.customer_id=C.Id JOIN Products AS P ON O.product_id=P.Id WHERE CONCAT(O.Id,date,P.name,O.price,C.full_name) LIKE N'%"+searchBox.Text+"%'", _connection);

            _connection.Open();
            _reader = _command.ExecuteReader();

            while (_reader.Read())
            {
                dgvOrders.Rows.Add(_reader[0].ToString(), Convert.ToDateTime(_reader[1].ToString()).ToString("dd.MM.yyyy"), _reader[2].ToString(), _reader[3].ToString(), _reader[4].ToString(), _reader[5].ToString(), _reader[6].ToString(), _reader[7].ToString());
            }

            _reader.Close();
            _connection.Close();
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dgvOrders.Columns[e.ColumnIndex].Name;

            if (columnName == "Delete")
            {
                if (MessageBox.Show("Ви точно хочете видалити цей запис", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateProductQuantity(e);
                    DeleteOrder(e);
                    MessageBox.Show("Запис було успішно видалено");
                }
            }

            LoadOrders();
        }

        private void DeleteOrder(DataGridViewCellEventArgs e)
        {
            _command = new SqlCommand("DELETE FROM Orders WHERE Id LIKE '" + dgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", _connection);
            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void UpdateProductQuantity(DataGridViewCellEventArgs e)
        {
            _command = new SqlCommand("UPDATE Products SET quantity=(quantity+@quantity) WHERE Id LIKE'" + dgvOrders.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", _connection);
            _command.Parameters.AddWithValue("@quantity", Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells[5].Value.ToString()));
            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
}
