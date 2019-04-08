using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TreeViewEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Map mp1 = new Map();
            mp1.Name = "This is the test string";
            mp1.Save(@"c:\test2.flw");
        }
    }
    public class Map
    {
        public string Name { get; set; }

        public void Save(string fileName)
        {
            using (BinaryWriter bw =
                    new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                bw.Write(Name);
            }
        }
        public void Load(string fileName)
        {
            using (BinaryReader br =
                    new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                Name = br.ReadString();
            }
        }

    }

}
