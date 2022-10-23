using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleThread
{
    public class ComboBoxItem
    {
        public System.Threading.Thread Thread { get; set; }
        public Circle Circle { get; set; }
        public ComboBoxItem(System.Threading.Thread thread, Circle circle)
        {
            this.Thread = thread;
            this.Circle = circle;
        }
        public override string ToString()
        {
            return Thread.Name;
            
        }
    }
}
