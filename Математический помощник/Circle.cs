using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Математический_помощник
{
    class Circle : Figure
    {
        // Поля класса Circle
        public static int parameters = 1;
        float radius;
        // Свойства класса Circle
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        // Конструкторы класса Circle
        public Circle(float radius)
        {
            Radius = radius;
        }
        public Circle(float[] values)
        {
            Radius = values[0];
        }
        // Определяет периметр окружности
        public float Perimeter()
        {
            return 2 * Radius * (float)Math.PI;
        }
        // Определяет площадь окружности
        public float Area()
        {
            return (float)Math.PI * (float)Math.Pow(Radius, 2);
        }
    }
}
