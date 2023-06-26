using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoToAudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listView1.View = View.Details;

            


        }
        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\bests\Downloads";
                
                openFileDialog.Filter = "video files (*.mp4)|*.mp4|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {


                    listView1.Columns.Add("제목");
                    listView1.Columns.Add("크기");
                    listView1.Columns.Add("날짜");

                    
                    foreach (String filepath in openFileDialog.FileNames)
                    {
                            //list_file.Items.Add(filepath.ToString());
                            //string[] row = { videoName, "2", "3" };
                            //var listViewItem = new ListViewItem(row);
                            listView1.Items.Add(filepath);
                            


                    }



                    //string audioName = Path.GetFileNameWithoutExtension(filepath) + ".mp3";

                    string videoName = openFileDialog.FileName;
                    
                    
                    ResizeListViewColumns(listView1);
                    //
                    // ffmpeg - i filename.mp4 filename.mp3
                    /*
                    string files = "-i " + "\"" + videoName + "\" " + audioName;
                    
                    string cmdtext = "/C ffmpeg " + files;
                    System.Diagnostics.Process.Start("CMD.exe", cmdtext);
                    */
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (var item in listView1.Items)
            {
                //Console.WriteLine(item.ToString());
                string path = Path.GetDirectoryName(item.ToString());

                path = path.Replace("ListViewItem: {", "");
                //path = path.Replace("}", "");
                string videoName = item.ToString().Replace("ListViewItem: {", "");
                videoName = videoName.Replace("}", "");
                string audioName = path + @"\"+Path.GetFileNameWithoutExtension(item.ToString()) + ".mp3";

                //Console.WriteLine(videoName);
                //Console.WriteLine(audioName);

                string files = "-i " + "\"" + videoName + "\" " + "\"" + audioName+"\" ";
                Console.WriteLine(files);
                string cmdtext = "/C ffmpeg " + files;
                System.Diagnostics.Process.Start("CMD.exe", cmdtext);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
