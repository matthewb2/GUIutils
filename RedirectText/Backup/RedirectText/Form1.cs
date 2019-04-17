using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace RedirectText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            redirectout();
        }
        public void redirectout(){

            var startinfo = new ProcessStartInfo(@"c:\cshello.exe")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            var process = new Process { StartInfo = startinfo };
            process.Start();

            var reader = process.StandardOutput;
            while (!reader.EndOfStream)
            {
                // the point is that the stream does not end until the process has 
                // finished all of its output.
                var nextLine = reader.ReadLine();
                //Console.WriteLine(nextLine);
                textBox1.Text += nextLine;
            }

            process.WaitForExit();
        
        }
    }
}
