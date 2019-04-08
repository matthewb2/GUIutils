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
using System.Xml.Serialization;

namespace GetAllControls
{
    public partial class Form1 : Form
    {

        MyFormState state = new MyFormState();

        MyFormState lbstate = new MyFormState();

        private Point MouseDownLocation;


        public Form1()
        {
            InitializeComponent();

           


            this.Load += new EventHandler(Form1_Load);
            lbstate.container = new List<Label>();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("config.xml"))
            {
                loadConfig();
            }

           
        }

        private void loadConfig()
        {
            XmlSerializer ser = new XmlSerializer(typeof(MyFormState));
            using (FileStream fs = File.OpenRead("config.xml"))
            {
                state = (MyFormState)ser.Deserialize(fs);


                
            }
        }



        int c = 0;
        

        protected void btnShowControls_Clicked(object sender, EventArgs e)
        {
            Control.ControlCollection coll = this.Controls;
            foreach (Control c in coll)
            {
                if (c != null)
                    MessageBox.Show(c.Text, "Index numb: " + coll.GetChildIndex(c, false));
            }
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                    StreamWriter sw = new StreamWriter("config.xml");
                           
                    XmlSerializer writer = new XmlSerializer(typeof(CarCollection));


                    CarCollection overview = new CarCollection();
                    List<Car> container = new List<Car>();
                    
                    foreach ( Label lt in lbstate.container)
                    {
                        Car item = new Car();

                        item.Make = lt.Text;
                        item.Model = lt.Location.Y;
                        container.Add(item);

                        //MessageBox.Show(lt.Location.Y.ToString());
                    }
                overview.cars = container;
                    
                    writer.Serialize(sw, overview);
                  
                    

                
                MessageBox.Show("Save Okay");
            }
            catch { MessageBox.Show("error");
            }
        }

      

        private void newlb_Click(object sender, EventArgs e)
        {
            Label lb = new Label();
            int n = 0;
            if (lbstate.container.Count > 0)
            {
                n = lbstate.container.Count;
              //  MessageBox.Show(n.ToString());
            }

            lb.Text = "This is a test";
            //lb.Size = new Size(200, 20);
            lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lb.Location = new Point(100, 100 + n * 30);

            this.Controls.Add(lb);

            lb.MouseDown += lb_MouseDown;
            lb.MouseMove += lb_MouseMove;

            // provide remaining implementation for the class


            lbstate.container.Add(lb);

        }
        private void lb_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("ddd");
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
               MouseDownLocation = e.Location;
            }
        }
        private void lb_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                Label lb = (Label)sender;
                lb.Left = e.X + lb.Left -MouseDownLocation.X;
                lb.Top = e.Y + lb.Top - MouseDownLocation.Y;

                //controltobeResized.Top = 100;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var item = lbstate.container[lbstate.container.Count - 1];
            this.Controls.Remove(item);

            //lbstate.container.Remove(lbstate.container.Count);
            lbstate.container.RemoveAt(lbstate.container.Count - 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();

            //string path = "cars.xml";

            XmlSerializer sr = new XmlSerializer(typeof(CarCollection));

            StreamReader reader = new StreamReader("config.xml");

            CarCollection readcar = new CarCollection();
            //List<Car> container = new List<Car>();

            readcar = (CarCollection)sr.Deserialize(reader);

            foreach (Car item in readcar.cars) {
                MessageBox.Show(item.Model.ToString());
            }
            


        }
    }






    public class MyFormState
    {
       
        public List<Label> container;

      
    }


    [Serializable()]
    [System.Xml.Serialization.XmlRoot("CarCollection")]
    public class CarCollection
    {
        [XmlElement]
        public List<Car> cars;
    }

    [Serializable()]
    public class Car
    {

        public string Make;

        public int Model;
    }
}
