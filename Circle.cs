using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CircleThread
{
    public class Circle
    {
        public decimal Radius { get; set; }
        public Brush Color { get; set; }
        public Circle(decimal radius, Color color)
        {
            this.Radius = radius;
            this.Color = new SolidBrush(color);
        }
    }
}
