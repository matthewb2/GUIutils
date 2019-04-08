using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrayIconEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // When the program begins, show the balloon on the icon for one second.
            notifyIcon1.BalloonTipText = "I am a NotifyIcon Balloon";

            notifyIcon1.BalloonTipTitle = "Welcome Message";



            notifyIcon1.ShowBalloonTip(1000);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
