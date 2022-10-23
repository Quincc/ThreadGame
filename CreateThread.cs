using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleThread
{
    public partial class CreateThreadForm : Form
    {
        private Circle circle;
        private string name;
        private System.Threading.ThreadPriority priority;
        public CreateThreadForm()
        {
            InitializeComponent();
            comboBoxPriority.DataSource = Enum.GetValues(typeof(System.Threading.ThreadPriority));
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                buttonColor.BackColor = colorDialog1.Color;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            circle = new Circle(numericUpDownRadius.Value, colorDialog1.Color);
            name = textBoxName.Text;
            priority = (System.Threading.ThreadPriority)comboBoxPriority.SelectedItem;
        }
        public Circle Circle => circle;
        public string ThreadName => name;
        public System.Threading.ThreadPriority Priority => priority;
    }
}
