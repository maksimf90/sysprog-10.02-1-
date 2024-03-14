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
    public partial class Form1 : Form
    {
        DB db;
        Product product;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB db = new DB("host=localhost; port=5432; username=postgres; password=11111; database=product");
            List<Product> product = db.getProduct();

            foreach (Product row in product) 
            {
                string image = row.image.ToString();
                string vendor = row.vendor.ToString();
                string name = row.name.ToString();
                string price = row.price.ToString();

                UserControl1 UserControl1 = new UserControl1(image, vendor, name, price);
                flowLayoutPanel1.Controls.Add(UserControl1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DB db = new DB("host=localhost; username=postgres; port=5432; password=11111; database=product");

            string searchKeyword = textBox1.Text.Trim().ToLower();
            flowLayoutPanel1.Controls.Clear();
            List<Product> product = db.getProduct();

            foreach (Product row in product)
            {
                string name = row.name.ToString().ToLower();
                if (name.Contains(searchKeyword))
                {
                    string image = row.image.ToString();
                    string vendor = row.vendor.ToString();
                    string price = row.price.ToString();
                    UserControl1 productControl = new UserControl1(image, vendor, row.name.ToString(), price);
                    flowLayoutPanel1.Controls.Add(productControl);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB("host=localhost; port=5432; username=postgres; password=11111; database=product");

            string selectedString = comboBox2.SelectedItem.ToString();
            List<Product> product;

            if (selectedString == "А-Я")
            {
                product = db.getProduct().OrderBy(p => p.name).ToList();
            }

            else if (selectedString == "Я-А")
            {
                product = db.getProduct().OrderBy(p => p.name).ToList();
            }

            else
            {
                product = db.getProduct().ToList();
            }

            flowLayoutPanel1.Controls.Clear();
            foreach (Product prod in product)
            {
                string image = prod.image.ToString();
                string vendor = prod.vendor.ToString();
                string price = prod.price.ToString();
                UserControl1 productControl = new UserControl1(image, vendor, prod.name.ToString(), price);
                flowLayoutPanel1.Controls.Add(productControl);
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB("host=localhost; port=5432; username=postgres; password=11111; database=product");

            string selectedSorting = comboBox1.SelectedItem.ToString();
            List<Product> product;

            product = db.getProduct().ToList();

            if(selectedSorting == "По убыванию")
            {
                product = product.OrderBy(p => p.price).ToList();
            }
            else if (selectedSorting == "По возрастанию")
            {
                product = product.OrderByDescending(p => p.price).ToList();
            }

            flowLayoutPanel1.Controls.Clear();

            foreach (Product prod in product)
            {
                string image = prod.image.ToString();
                string vendor = prod.vendor.ToString();
                string price = prod.price.ToString();
                UserControl1 productControl = new UserControl1(image, vendor, prod.name.ToString(), price);
                flowLayoutPanel1.Controls.Add(productControl);
            }
        }
    }
}
