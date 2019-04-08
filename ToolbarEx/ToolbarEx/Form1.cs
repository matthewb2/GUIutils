using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolbarEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var panel = new Panel()
            {
                BackColor = Color.White,
                MinimumSize = new Size(150, 72),
                Size = MinimumSize,
            };
            panel.Paint += (s, e) => {
                TextRenderer.DrawText(e.Graphics, "Pop-up Panel",
                SystemFonts.DefaultFont, panel.ClientRectangle,
                Color.Black, Color.Empty,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            var hostTool = new ToolStripControlHost(panel)
            {
                Padding = Padding.Empty,
                Margin = Padding.Empty
            };

            var downButton = new ToolStripDropDownButton("Panel Menu")
            {
                Alignment = ToolStripItemAlignment.Right,
                DisplayStyle = ToolStripItemDisplayStyle.Text,
                DropDownDirection = ToolStripDropDownDirection.BelowLeft,
            };

            ((ToolStripDropDownMenu)downButton.DropDown).ShowCheckMargin = false;
            ((ToolStripDropDownMenu)downButton.DropDown).ShowImageMargin = false;
            downButton.DropDown.AutoSize = false;
            downButton.DropDown.Size = new Size(panel.Width + 12, panel.Height + 4);
            downButton.DropDown.Items.Add(hostTool);
            //var tool = new ToolStrip();
            toolStrip1.Items.Add(downButton);
            //this.Controls.Add(tool);
        }
    }
}
