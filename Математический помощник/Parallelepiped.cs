using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Математический_помощник
{
    class Parallelepiped : Figure
    {
        // Поля класса Parallelepiped
        float height;
        public static int parameters = 3;
        // Свойства класса Parallelepiped
        public float Height
        {
            get { return height; }
            set { height = value; }
        }
        // Конструкторы класса Parallelepiped
        public Parallelepiped(float length, float width, float height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public Parallelepiped(float[] values)
        {
            Length = values[0];
            Width = values[1];
            Height = values[2];
        }
        // Определяет площадь параллелепипеда
        public float Area()
        {
            return 2 * (Length * Width + Length * Height + Width * Height);
        }
        // Определяет объём параллелепипеда
        public float Cubage()
        {
            return Length * Width * Height;
        }
    }
}
