namespace StorageManagement
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOrders = new StorageManagement.CustomerButton();
            this.btnStaff = new StorageManagement.CustomerButton();
            this.btnProducts = new StorageManagement.CustomerButton();
            this.btnCategories = new StorageManagement.CustomerButton();
            this.btnCustomers = new StorageManagement.CustomerButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelStaff = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnOrders);
            this.panel1.Controls.Add(this.btnStaff);
            this.panel1.Controls.Add(this.btnProducts);
            this.panel1.Controls.Add(this.btnCategories);
            this.panel1.Controls.Add(this.btnCustomers);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelStaff);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1285, 104);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(691, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Замовлення";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(412, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Категорії";
            // 
            // btnOrders
            // 
            this.btnOrders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOrders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOrders.HoverImage = global::StorageManagement.Properties.Resources.purchase_hover;
            this.btnOrders.Image = global::StorageManagement.Properties.Resources.purchase_normal;
            this.btnOrders.Location = new System.Drawing.Point(709, 11);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.NormalImage = global::StorageManagement.Properties.Resources.purchase_normal;
            this.btnOrders.Size = new System.Drawing.Size(68, 62);
            this.btnOrders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnOrders.TabIndex = 9;
            this.btnOrders.TabStop = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStaff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStaff.HoverImage = global::StorageManagement.Properties.Resources.staff_hover;
            this.btnStaff.Image = global::StorageManagement.Properties.Resources.staff_normal;
            this.btnStaff.Location = new System.Drawing.Point(855, 11);
            this.btnStaff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.NormalImage = global::StorageManagement.Properties.Resources.staff_normal;
            this.btnStaff.Size = new System.Drawing.Size(68, 62);
            this.btnStaff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnStaff.TabIndex = 9;
            this.btnStaff.TabStop = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProducts.HoverImage = global::StorageManagement.Properties.Resources.product_hover;
            this.btnProducts.Image = global::StorageManagement.Properties.Resources.product_normal;
            this.btnProducts.Location = new System.Drawing.Point(282, 11);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.NormalImage = global::StorageManagement.Properties.Resources.product_normal;
            this.btnProducts.Size = new System.Drawing.Size(68, 62);
            this.btnProducts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnProducts.TabIndex = 9;
            this.btnProducts.TabStop = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCategories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCategories.HoverImage = global::StorageManagement.Properties.Resources.category_hover;
            this.btnCategories.Image = global::StorageManagement.Properties.Resources.category_normal;
            this.btnCategories.Location = new System.Drawing.Point(419, 11);
            this.btnCategories.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.NormalImage = global::StorageManagement.Properties.Resources.category_normal;
            this.btnCategories.Size = new System.Drawing.Size(68, 62);
            this.btnCategories.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCategories.TabIndex = 9;
            this.btnCategories.TabStop = false;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCustomers.HoverImage = global::StorageManagement.Properties.Resources.customer_hover;
            this.btnCustomers.Image = global::StorageManagement.Properties.Resources.customer_normal1;
            this.btnCustomers.Location = new System.Drawing.Point(565, 11);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.NormalImage = global::StorageManagement.Properties.Resources.customer_normal1;
            this.btnCustomers.Size = new System.Drawing.Size(68, 62);
            this.btnCustomers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCustomers.TabIndex = 9;
            this.btnCustomers.TabStop = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::StorageManagement.Properties.Resources.track;
            this.pictureBox1.Location = new System.Drawing.Point(55, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // labelStaff
            // 
            this.labelStaff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStaff.AutoSize = true;
            this.labelStaff.BackColor = System.Drawing.Color.Transparent;
            this.labelStaff.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStaff.Location = new System.Drawing.Point(851, 77);
            this.labelStaff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStaff.Name = "labelStaff";
            this.labelStaff.Size = new System.Drawing.Size(85, 20);
            this.labelStaff.TabIndex = 7;
            this.labelStaff.Text = "Персонал";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(561, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Покупці";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(284, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Товари";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Облік товарів";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 104);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1285, 543);
            this.panelMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1285, 647);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private CustomerButton btnCustomers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private CustomerButton btnOrders;
        private CustomerButton btnProducts;
        private CustomerButton btnCategories;
        private System.Windows.Forms.Panel panelMain;
        public System.Windows.Forms.Label labelStaff;
        public CustomerButton btnStaff;
    }
}