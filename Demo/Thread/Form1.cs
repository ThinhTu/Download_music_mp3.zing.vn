using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Threading.Thread frm2  = new System.Threading.Thread(new ThreadStart(StartForm2));
            frm2.Start();
        }

        Form2 form2 = new Form2();
        private void StartForm2()
        {
            Application.Run(form2=new Form2());
        }

        

        private void transferText(string text)
        {
            if (form2.textBox1.InvokeRequired)
                form2.textBox1.Invoke((MethodInvoker)
                delegate()
                {
                    transferText(text);
                });
            else
            {
                form2.textBox1.Text = text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                transferText(textBox1.Text);
        }
    }
}
