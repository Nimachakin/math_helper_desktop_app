using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Математический_помощник
{
    class Cylinder : Figure
    {
        // Поля класса Cylinder
        float radius, height;
        public static int parameters = 2;
        // Свойства класса Cylinder
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public float Height
        {
            get { return height; }
            set { height = value; }
        }
        // Конструкторы класса Cylinder
        public Cylinder(float radius, float height)
        {
            Radius = radius;
            Height = height;
        }
        public Cylinder(float[] values)
        {
            Radius = values[0];
            Height = values[1];
        }
        // Определяет площадь цилиндра
        public float Area()
        {
            return 2 * (float)Math.PI * Radius * (Radius + Height);
        }
        // Определяет объём цилиндра
        public float Cubage()
        {
            return (float)Math.PI * (float)Math.Pow(Radius, 2) * Height;
        }
    }
}
