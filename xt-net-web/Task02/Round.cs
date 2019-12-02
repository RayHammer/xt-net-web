using System;

namespace Task02
{
    /// <summary>
    /// Should've been called a Circle IMO
    /// </summary>
    class Round
    {
        public Round(float x = 0.0f, float y = 0.0f, float r = 1.0f)
        {
            X = x;
            Y = y;
            if (r < 0)
            {
                throw new ArgumentOutOfRangeException("r", r, "Circle's radius is incorrect");
            }
            R = r;
        }

        public float X
        {
            get => x;
            set => x = value;
        }

        public float Y
        {
            get => y;
            set => y = value;
        }

        public float R
        {
            get => r;
            set
            {
                if (r < 0)
                {
                    throw new ArgumentOutOfRangeException("r", r, "Circle's radius is incorrect");
                }
                r = value;
            }
        }

        public float Circumference
        {
            get => (float)(2 * Math.PI * r);
        }

        public float Area
        {
            get => (float)(Math.PI * Math.Pow(r, 2));
        }

        public bool IntersectsWithPoint(float x, float y)
        {
            if (Math.Pow(x - this.x, 2) + Math.Pow(y - this.y, 2) <= Math.Pow(r, 2))
            {
                return true;
            }
            return false;
        }

        private float x, y;
        private float r;
    }
}
