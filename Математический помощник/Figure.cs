using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Математический_помощник
{
    abstract class Figure
    {
        // Поля класса Figure
        float length, width;
        // Свойства класса Figure
        public float Length
        {
            get { return length; }
            set { length = value; }
        }
        public float Width
        {
            get { return width; }
            set { width = value; }
        }
    }
}
