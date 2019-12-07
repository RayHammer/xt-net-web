using System;

namespace Task02
{
    class Triangle
    {
        public Triangle(float a, float b, float c)
        {
            float p = (a + b + c) / 2;
            if (a > p || b > p || c > p)
            {
                throw new ArgumentException("Attempted to create an impossible triangle");
            }
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public float Perimeter
        {
            get => a + b + c;
        }

        public float Area
        {
            get
            {
                float p = Perimeter / 2;
                return (float)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        private float a, b, c;
    }
}
