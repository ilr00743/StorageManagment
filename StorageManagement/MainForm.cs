using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageManagement
{
    public partial class MainForm : Form
    {
        private Form _activeChildForm;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductsForm());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CategoriesForm());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CustomersForm());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StaffForm());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrdersForm());
        }

        private void OpenChildForm(Form childForm)
        {
            if (_activeChildForm != null) _activeChildForm.Close();

            _activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
