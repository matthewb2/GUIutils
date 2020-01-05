using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RulerEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Load += new EventHandler(this.Form1_Load); //FIRES!
            this.Paint += new PaintEventHandler(this.Form1_Paint); //FIRES!

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // RulerEdit.TextRulerControl.TextRuler Ruler = new TextRulerControl.TextRuler();

        }
        private void Form1_Paint(object sender, PaintEventArgs pe)
        {
            // Declares the Graphics object and sets it to the Graphics object  
            // supplied in the PaintEventArgs.  
            Graphics g = pe.Graphics;
            // Insert code to paint the form here.
            //RulerEdit.TextRulerControl.TextRuler ruler = new TextRulerControl.TextRuler();
            
            
        }
    }
}
