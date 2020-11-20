using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Математический_помощник
{
    class Sphere : Figure
    {
        // Поля класса Sphere
        float radius;
        public static int parameters = 1;
        // Свойства класса Sphere
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        // Конструкторы класса Sphere
        public Sphere(float radius)
        {
            Radius = radius;
        }
        public Sphere(float[] values)
        {
            Radius = values[0];
        }
        // Определяет площадь шара
        public float Area()
        {
            return (float)Math.PI * (float)Math.Pow(Radius, 4);
        }
        // Определяет объём шара
        public float Cubage()
        {
            return (float)(4 / 3) * (float)Math.PI * (float)Math.Pow(Radius, 3);
        }
    }
}
