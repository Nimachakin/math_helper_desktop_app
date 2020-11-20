using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Математический_помощник
{
    class Rectangle : Figure
    {
        // Поля класса Rectangle
        public static int parameters = 2;
        // Конструкторы класса Rectangle
        public Rectangle(float length, float width)
        {
            Length = length;
            Width = width;
        }
        public Rectangle(float[] values)
        {
            Length = values[0];
            Width = values[1];
        }
        // Определяет периметр прямоугольника
        public float Perimeter()
        {
            return (Length + Width) * 2;
        }
        // Определяет площадь прямоугольника
        public float Area()
        {
            return Length * Width;
        }
    }
}
