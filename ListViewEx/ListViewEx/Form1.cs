using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewEx
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();

            listView1.View = View.Details;

            listView1.Columns.Add("Key");
            listView1.Columns.Add("Value");

            ListViewItem lvi1 = new ListViewItem();

            lvi1.Text = "aaa";
            lvi1.SubItems.Add("12321");
            listView1.Items.Add(lvi1);
        }
    }
}
