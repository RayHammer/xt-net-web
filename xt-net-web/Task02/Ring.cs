using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Ring : Round
    {
        public Ring(float x, float y, float rIn, float rOut)
        {
            X = x;
            Y = y;
            RInner = rIn;
            R = rOut;
        }

        public float RInner
        {
            get; set;
        }

        public new float Area
        {
            get => base.Area - (float)(Math.PI * Math.Pow(RInner, 2));
        }

        public new float Circumference
        {
            get => base.Circumference + (float)(2 * Math.PI * RInner);
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append(Name);
            sb.Append('{');
            sb.Append("X = ").Append(X).Append(',');
            sb.Append("Y = ").Append(Y).Append(',');
            sb.Append("R = ").Append(R).Append(',');
            sb.Append("RInner = ").Append(RInner).Append(',');
            sb.Append('}');
            return sb.ToString();
        }

        protected override string Name => "Ring";
    }
}
