using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CircleThread
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            graphics = CreateGraphics();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateThreadForm ctf = new CreateThreadForm();

            if(ctf.ShowDialog() == DialogResult.OK)
            {
                System.Threading.Thread thread = new System.Threading.Thread(func);
                thread.Name = ctf.ThreadName;
                thread.Priority = ctf.Priority;
                ComboBoxItem item = new ComboBoxItem(thread, ctf.Circle);
                listBox1.Items.Add(item);
            }
        }

        private void func(object obj)
        {
            Circle circle = (Circle)obj;
            while (true)
            {
                int x = random.Next(0, ClientSize.Width);
                int y = random.Next(0, ClientSize.Height);
                lock (graphics)
                {
                    graphics.FillEllipse(circle.Color, x, y, (float)circle.Radius * 2, (float)circle.Radius * 2);
                }
                System.Threading.Thread.Sleep(200);
            }
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {   
            foreach (ComboBoxItem item in listBox1.SelectedItems)
            {
                item.Thread.Start(item.Circle);
            }
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            foreach (ComboBoxItem item in listBox1.SelectedItems)
            {
                item.Thread.Abort();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ComboBoxItem item in listBox1.Items)
            {
                item.Thread.Abort();
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            graphics = CreateGraphics();
        }
    }
}
