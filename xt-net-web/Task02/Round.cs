using System;

namespace Task02
{
    class Round : Figure
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
            get; set;
        }

        public float Y
        {
            get; set;
        }

        public float R
        {
            get => r;
            set
            {
                r = value;
                if (r < 0)
                {
                    throw new ArgumentOutOfRangeException("R", r, "Circle's radius is incorrect");
                }
            }
        }

        public float Circumference
        {
            get => (float)(2 * Math.PI * R);
        }

        public float Area
        {
            get => (float)(Math.PI * Math.Pow(R, 2));
        }

        public bool IntersectsWithPoint(float x, float y)
        {
            if (Math.Pow(x - X, 2) + Math.Pow(y - Y, 2) <= Math.Pow(R, 2))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append(Name);
            sb.Append('{');
            sb.Append("X = ").Append(X).Append(',');
            sb.Append("Y = ").Append(Y).Append(',');
            sb.Append("R = ").Append(R).Append(',');
            sb.Append('}');
            return sb.ToString();
        }

        protected override string Name => "Round";

        private float r;
    }
}
