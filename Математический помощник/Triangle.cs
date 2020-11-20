using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Математический_помощник
{
    class Triangle : Figure
    {
        // Поля класса Triangle
        float height;
        public static int parameters = 3;
        // Свойства класса Triangle
        public float Height
        {
            get { return height; }
            set { height = value; }
        }
        // Конструкторы класса Triangle
        public Triangle(float lineA, float lineB, float lineC)
        {
            Length = lineA;
            Width = lineB;
            Height = lineC;
        }
        public Triangle(float[] values)
        {
            Length = values[0];
            Width = values[1];
            Height = values[2];
        }
        // Определяет периметр треугольника
        public float Perimeter()
        {
            return Length + Width + Height;
        }
        // Определяет площадь треугольника
        public float Area()
        {
            return Length;
        }
    }
}
