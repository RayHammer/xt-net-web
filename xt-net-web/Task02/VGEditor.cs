using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class VGEditor
    {
        public VGEditor()
        {
            figures = new List<Figure>();
        }

        public void Run()
        {
            bool run = true;
            while (run)
            {
                var input = Console.ReadLine().Split(' ');
                switch (input[0].ToLower())
                {
                case "add":
                    switch (input[1].ToLower())
                    {
                    case "round":
                        var x = float.Parse(input[2]);
                        var y = float.Parse(input[3]);
                        var r = float.Parse(input[4]);
                        Add(new Round(x, y, r));
                        break;
                    }
                    break;
                case "display":
                    Display();
                    break;
                case "exit":
                default:
                    run = false;
                    break;
                }
            }
        }

        protected void Add(Figure figure)
        {
            figures.Add(figure);
            Console.WriteLine("Added new figure:");
            Console.WriteLine(figure.ToString());
        }

        protected void Display()
        {
            foreach (var i in figures)
            {
                Console.WriteLine(i.ToString());
            }
        }

        private List<Figure> figures;
    }

    abstract class Figure
    {
        public override string ToString()
        {
            return Name + "{}";
        }

        protected string Name => "Figure";
    }
}
