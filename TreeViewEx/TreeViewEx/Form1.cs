using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

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

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FZipFormat mp1 = new FZipFormat();


            mp1.audio = Encoding.ASCII.GetBytes("This is the test string");
            Image image1 = Image.FromFile("c:\\test.jpg");
            

            mp1.image = ImageToByteArray(image1);
            mp1.Save(@"c:\test2.flw");

            mp1.Load(@"c:\test2.flw");

            MemoryStream ms = new MemoryStream(mp1.image);
            Image img = Image.FromStream(ms);

            img.Save(@"c:\out.jpg", ImageFormat.Png);

            //bmp.Save(@"c:\out.jpg", ImageFormat.Jpeg);

            // From byte array to string
            string header = System.Text.Encoding.UTF8.GetString(mp1.header, 0, 2);
            string body = System.Text.Encoding.UTF8.GetString(mp1.audio, 0, mp1.audio.Length);
           

            TreeNode svrNode = new TreeNode("Header", 0, 0);
            svrNode.Nodes.Add(mp1.header.ToString(), header, 0, 0);
            
            // 두번째 TreeView 아이템 - 네트웍
            TreeNode netNode = new TreeNode("Audio", 1, 1);
            netNode.Nodes.Add("", body, 1, 1);
            
            // 2개의 노드를 TreeView에 추가
            treeView1.Nodes.Add(svrNode);
            treeView1.Nodes.Add(netNode);

            // 모든 트리 노드를 보여준다
            treeView1.ExpandAll();
        }
    }
    public class FZipFormat
    {
        public byte[] header;
        public byte[] audio;
        public byte[] video;
        public byte[] image;

        public FZipFormat()
        {
            //long bytes1 = GC.GetTotalMemory(false);
            header = new byte[4];
            audio = new byte[1024];
            header = ASCIIEncoding.ASCII.GetBytes("MK");

            Array.Resize(ref header, 4);
            
            


        }



        public void Save(string fileName)
        {
            using (BinaryWriter bw =
                    new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                //bw.Write(Header);
                bw.Write(header.Concat(image).ToArray());
            }
        }
        public void Load(string fileName)
        {
            using (BinaryReader br =
                    new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                this.header = br.ReadBytes(4); // 4바이트 읽기
                long length = new System.IO.FileInfo(fileName).Length;
                int len = Convert.ToInt32(length);
                this.image = new byte[len + 1];
                this.image = br.ReadBytes(len+1);

            }
        }

    }

}
