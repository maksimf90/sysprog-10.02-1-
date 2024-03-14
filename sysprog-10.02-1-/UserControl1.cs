using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sysprog_10._02_1_
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1(string image, string name, string price, string vendor)
        {
            InitializeComponent();

            pictureBox1.Image = Image.FromFile(image);
            labelVen.Text = vendor;
            labelName.Text = name;
            labelPrice.Text = price;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
