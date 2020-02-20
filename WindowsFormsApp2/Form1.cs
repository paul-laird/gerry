using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{


    public partial class Form1 : Form
    {


        public delegate int computeOrderTotalCost(Order o);
        public static SortedList<int, Product> products;
        SortedList<int, computeOrderTotalCost> discounts;
        Order o;
        public Form1()
        {
            InitializeComponent();
            products = new SortedList<int, Product>();
            discounts = new SortedList<int, computeOrderTotalCost>();
            products[1] = new Product() { MinOrder = 1, UnitPrice = 1, ProductName = "A" };
            products[2] = new Product() { MinOrder = 1, UnitPrice = 2, ProductName = "B" };
            o = new Order() { OrderID = 1, quantities = new SortedList<int, int>() };
            discounts[1] = Form1.tenOffFifty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            o.quantities[int.Parse(textBoxProduct.Text)] = int.Parse(textBoxQty.Text);
            MessageBox.Show("Added");
            textBoxQty.Clear();
            textBoxProduct.Clear();
        }
        public int normalTotal(Order o)
        {
            int total = 0;
            foreach (KeyValuePair<int, int> kvp in o.quantities)
            {
                total += kvp.Value * products[kvp.Key].UnitPrice;
            }
            return total;
        }

        public static int tenOffFifty(Order o)
        {
            int total = 0;
            foreach (KeyValuePair<int, int> kvp in o.quantities)
            {
                total += kvp.Value * Form1.products[kvp.Key].UnitPrice;
            }
            if (total > 50)
                total -= 10;
            return total;
        }
        private void buttonTotal_Click(object sender, EventArgs e)
        {
            int disc = 0;
            computeOrderTotalCost c;
            if (int.TryParse(textBoxDiscount.Text, out disc) && discounts.ContainsKey(disc))
            {
                c = discounts[disc];
            }
            else
            {
                c = normalTotal;
            }
            MessageBox.Show(""+c(o));
        }
    }
}
