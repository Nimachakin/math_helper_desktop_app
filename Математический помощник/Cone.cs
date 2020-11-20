using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Математический_помощник
{
    class Cone : Figure
    {
        // Поля класса Cone
        float radius, height;
        public static int parameters = 2;
        // Свойства класса Cone
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
        // Конструкторы класса Cone
        public Cone(float radius, float height)
        {
            Radius = radius;
            Height = height;
        }
        public Cone(float[] values)
        {
            Radius = values[0];
            Height = values[1];
        }
        // Определяет площадь конуса
        public float Area()
        {
            float generatric = (float)Math.Sqrt(
                (float)Math.Pow(Radius, 2) + (float)Math.Pow(Height, 2));
            return (float)Math.PI * Radius * (Radius + generatric);
        }
        // Определяет объём конуса
        public float Cubage()
        {
            return (float)Math.PI * (float)Math.Pow(Radius, 2) * (Height / 3);
        }
    }
}
