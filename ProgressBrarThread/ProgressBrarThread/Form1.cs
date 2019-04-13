using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ProgressBrarThread
{
    public partial class Form1 : Form
    {
        Thread thread1;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             progressBar1.Minimum = 0; //크로스 쓰레딩을 피하기 위해 설정은 메인쓰레드가 실행하는 곳에 넣었습니다
            progressBar1.Maximum = 1000000; 
            thread1 = new Thread(new ThreadStart(ThreadGOGO));
   
            
            thread1.Start();  //ThreadGOGO메소드를 새로운 쓰레드가 실행합니다

        }

        //이번엔 파라미터를 하나 넘겨줘야 하기에 델리게이트를 직접 정의 했습니다
            delegate void ProgvarCall(int var);

            private void ThreadGOGO()
            {
                        for (int i = 0; i < 1000000; i++) 
                        {    //Control.Invoke는 델리게이트와 param Object[]형식을 받는 오버로드된 메소드가 있습니다.
                 // param Object[]파라미터는 델리게이트의 파라미터를 받아서 넘겨주죠 여기선 i값을 Object[]형식으로
                             // 만들어서 넘겨주었습니다
                            progressBar1.Invoke(new ProgvarCall(ProgValueSetting) ,new object[]{i} );
                        }
             }

            private void ProgValueSetting(int var)
            {
                        progressBar1.Value = var;
             }

            private void button2_Click(object sender, EventArgs e)
            {
                // Abort thr thread 
                // Using Abort() method 
                thread1.Abort(); 
            }

    }
}
