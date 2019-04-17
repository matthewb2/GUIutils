using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace ListViewEx
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();

            listView1.View = View.Details;

            List<Item> items;
            using (StreamReader r = new StreamReader(@"C:\file.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Item>>(json);
            }

            listView1.Columns.Add("Key");
            listView1.Columns.Add("Value");

            ListViewItem lvi1 = new ListViewItem();

            foreach (Item tt in items)
            {
                lvi1.Text = tt.light;
                lvi1.SubItems.Add(tt.stamp);
            }

            
            listView1.Items.Add(lvi1);
        }
    }
    public class Item
    {
        public int millis;
        public string stamp;
        public DateTime datetime;
        public string light;
        public float temp;
        public float vcc;
    }
}
