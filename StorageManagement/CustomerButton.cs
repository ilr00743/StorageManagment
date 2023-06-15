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
    public partial class CustomerButton : PictureBox
    {
        private Image _normalImage;
        private Image _hoverImage;

        public CustomerButton()
        {
            InitializeComponent();
        }

        public Image NormalImage { get => _normalImage; set => _normalImage = value; }
        public Image HoverImage { get => _hoverImage; set => _hoverImage = value; }


        private void CustomerButton_MouseLeave(object sender, EventArgs e)
        {
            Image = _normalImage;
        }

        private void CustomerButton_MouseHover(object sender, EventArgs e)
        {
            Image = _hoverImage;
        }
    }
}
