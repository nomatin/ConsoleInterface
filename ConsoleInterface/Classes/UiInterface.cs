using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface.Classes
{
    class UiInterface
    {

        public int height { set; get; }
        public int width { set; get; }

        private Elements[,] elements;
        private Dictionary<string, Elements> countries = new Dictionary<string, Elements>();
        private int[] points = new int[2] { 0, 0 };
        public UiInterface(int height, int width)
        {
            this.height = height;
            this.width = width;
            elements = new Elements[height, width];
        }

        public void add(Elements element, string name)
        {
            try
            {
                countries.Add(name, element);
                elements[element.y, element.x] = element;
            }
            catch
            {

            }
        }
        public Elements get_element(string name)
        {
            return countries[name];
        }
        public void display()
        {
            string render_display = "";
            Elements active = null;
            for (int i = 0; i < height; i++)
            {
                render_display += new String(':', width) + "\n";

            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(render_display);
            while (true)
            {
                ConsoleKeyInfo key;
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow && points[1] != 0)
                {
                    points[1]--;
                }
                else if (key.Key == ConsoleKey.DownArrow && points[1] < height - 1)
                {
                    points[1]++;
                }
                else if (key.Key == ConsoleKey.LeftArrow && points[0] != 0)
                {
                    points[0]--;
                }
                else if (key.Key == ConsoleKey.RightArrow && points[0] < width - 1)
                {
                    points[0]++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {

                    if (active != null)
                    {
                        active.effect();
                    }
                }
                else
                {
                    continue;
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(render_display);

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(points[0]);
                Console.WriteLine(points[1]);
                active = null;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        if (elements[y, x] != null)
                        {
                            string[] render = elements[y, x].render(false);

                            if ((y >= points[1] && y < (points[1] + render.Length)) && (x <= points[0] && x > points[0] - render[0].Length))
                            {
                                active = elements[y, x];
                                render = elements[y, x].render(true);
                            }



                            for (int i = 0; i < render.Length; i++)
                            {
                                Console.SetCursorPosition(elements[y, x].x, elements[y, x].y - i);
                                Console.WriteLine(render[render.Length - 1 - i]);
                            }
                        }


                    }


                }
                Console.SetCursorPosition(points[0], points[1]);
                Console.WriteLine('$');

            }

        }
    }
}
