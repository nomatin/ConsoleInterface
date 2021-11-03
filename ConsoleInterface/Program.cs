using System;
using System.Collections.Generic;

namespace ConsoleInterface
{
    class Program
    {
        delegate void buttons_fun();
        static UiInterface ui = new UiInterface(40, 150);
        static void Main(string[] args)
        {
            buttons_fun fin = button1;
            Button button = new Button(10, 10, 21, fin, "Привет мир", "/|||\\", "\\|||/");
            fin = entry1;
            Entry entry = new Entry(20, 20, 21, fin, "Приве");
            Label label = new Label(10, 5, 0, "Text");
            ui.add(label, "label");
            ui.add(button, "button");
            ui.add(entry, "entry");
            ui.display();
            Console.WriteLine(button.render(true));
            
        }
        static void button1()
        {
            ui.get_element("button").text = "Ура я нажал на кнопку".ToCharArray();
        }
        static void entry1()
        {
            ui.get_element("button").text = ui.get_element("entry").text;
        }
    }
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
                else if(key.Key == ConsoleKey.DownArrow && points[1] < height-1)
                {
                    points[1]++;
                }
                else if(key.Key== ConsoleKey.LeftArrow && points[0] != 0)
                {
                    points[0]--;
                }
                else if(key.Key == ConsoleKey.RightArrow && points[0] < width-1 )
                {
                    points[0]++;
                }
                else if(key.Key == ConsoleKey.Enter)
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
                for (int y = 0; y< height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        
                        if (elements[y,x] != null)
                        {
                            string[] render  = elements[y, x].render(false);
                            
                            if ((x >= points[1] && x < (points[1] + render.Length)) && (y<= points[0] && y > points[0]-render[0].Length))
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
    abstract class Elements
    {
        public bool activ { get; }
        public int x { set; get; }
        public int y { set; get; }
        public int width { set; get; }
        public char СalmBadge { set; get; }
        public char InvertBadge { set; get; }
        public char ConectorBafge { set; get; }
        public char[] text { set; get; }
        public string LeftVisual { set; get; }
        public string RightVisual { set; get; }
        public Elements(int x, int y,int width, string text, string LeftVisual,string RightVisual, char ConectorBafge, char СalmBadge,  char InvertBadge,  bool activ)
        {
            this.width = width;
            this.activ = activ;
            this.x = x;
            this.y = y;
            this.text = text.ToCharArray();
            this.LeftVisual = LeftVisual;
            this.RightVisual = RightVisual;
            this.ConectorBafge = ConectorBafge;
            this.СalmBadge = СalmBadge;
            this.InvertBadge = InvertBadge;
        }
        public abstract string[] render(bool highlight);
        public abstract void effect();
    }
    
    class Button : Elements
    {
        private Delegate action;
        private const string leftstandartVisual = "/|\\";
        private const string rightstandartVisual = "\\|/";
        private const char StandartConectorBafge = '-';
        private const char StandartСalmBadge = '*';
        private const char StandartInvertBadge = '#';
        public Button(int x, int y, int width, Delegate action, string text, string LeftVisual, string RightVisual, char ConectorBafge, char СalmBadge, char InvertBadge) : base(x, y, width, text, LeftVisual, RightVisual, ConectorBafge, СalmBadge, InvertBadge, true)
        {
            this.action = action;
        }
        public Button(int x, int y, int width, Delegate action, string text, string LeftVisual, string RightVisual) : base(x, y, width, text, LeftVisual, RightVisual, StandartConectorBafge, StandartСalmBadge, StandartInvertBadge, true)
        {
            this.action = action;
        }
        public Button(int x, int y,int width, Delegate action, string text) : base(x, y, width, text, leftstandartVisual, rightstandartVisual, StandartConectorBafge, StandartСalmBadge, StandartInvertBadge, true)
        {
            this.action = action;
        }
        public override string[] render(bool highlight)
        {

            string[] render_button = new string[LeftVisual.Length];

            int len_but;
            if (width > text.Length + 3)
            {
                len_but = width;
            }
            else
            {
                len_but = text.Length + 3;
            }
            for(int i = 0; i < LeftVisual.Length; i++)
            {
                string string_render = "";
                string_render += LeftVisual[i];

                for(int j = 1; j <= len_but; j++)
                {
                    if (j != len_but) {
                        if (i == 0 || i == LeftVisual.Length - 1)
                        {
                            string_render += ConectorBafge;
                        }
                        else if (i == LeftVisual.Length / 2 && (j > (len_but-text.Length)/2  && j < (len_but - text.Length) / 2  + text.Length +1))
                        {
                            if(text[j - (len_but - text.Length) / 2-1] == ' ') {
                                if (highlight)
                                {
                                    string_render += InvertBadge;
                                }
                                else
                                {
                                    string_render += СalmBadge;
                                }
                                
                            }
                            else
                            {
                                string_render += text[j - (len_but - text.Length) / 2 - 1];
                            }
                            
                        }
                        else
                        {
                            if (highlight)
                            {
                                string_render += InvertBadge;
                            }
                            else
                            {
                                string_render += СalmBadge;
                            }
                        }
                    }
                    else
                    {
                        string_render += RightVisual[i];
                    }
                    render_button[i] = string_render;

                }
                
            }
            return render_button;
        }
        public override void effect()
        {
            action.DynamicInvoke();
        }
    }
    
    class Entry : Elements
    {
        private Delegate action;
        private const string leftstandartVisual = " | ";
        private const string rightstandartVisual = " | ";
        private const char StandartConectorBafge = '-';
        private const char StandartСalmBadge = '-';
        private const char StandartInvertBadge = '_';
        public Entry(int x, int y, int width, Delegate action, string text, string LeftVisual, string RightVisual, char ConectorBafge, char СalmBadge, char InvertBadge) : base(x, y, width, text, LeftVisual, RightVisual, ConectorBafge, СalmBadge, InvertBadge, true)
        {
            this.action = action;
        }
        public Entry(int x, int y, int width, Delegate action, string text, string LeftVisual, string RightVisual) : base(x, y, width, text, LeftVisual, RightVisual, StandartConectorBafge, StandartСalmBadge, StandartInvertBadge, true)
        {
            this.action = action;
        }
        public Entry(int x, int y, int width, Delegate action, string text) : base(x, y, width, text, leftstandartVisual, rightstandartVisual, StandartConectorBafge, StandartСalmBadge, StandartInvertBadge, true)
        {
            this.action = action;
        }
        public override string[] render(bool highlight)
        {

            string[] render_button = new string[LeftVisual.Length];

            int len_but;
            if (width > text.Length + 3)
            {
                len_but = width;
            }
            else
            {
                len_but = text.Length + 3;
            }
            for (int i = 0; i < LeftVisual.Length; i++)
            {
                string string_render = "";
                string_render += LeftVisual[i];

                for (int j = 1; j <= len_but; j++)
                {
                    if (j != len_but)
                    {
                        if (i == 0 || i == LeftVisual.Length - 1)
                        {
                            string_render += ConectorBafge;
                        }
                        else if (i == LeftVisual.Length / 2)
                        {
                            if(!highlight && j > 0 && j <= text.Length)
                            {
                                string_render += text[j - 1];
                            }
                            else
                            {
                                if (highlight)
                                {
                                    string_render += InvertBadge;
                                    
                                }
                                else
                                {
                                    string_render += СalmBadge;
                                }
                                
                            }

                        }
                        else
                        {
                            if (highlight)
                            {
                                string_render += InvertBadge;
                            }
                            else
                            {
                                string_render += СalmBadge;
                            }
                        }
                    }
                    else
                    {
                        string_render += RightVisual[i];
                    }
                    render_button[i] = string_render;

                }

            }
            return render_button;
        }
        
        public override void effect()
        {
            Console.SetCursorPosition(x+1, y-1);
            text = Console.ReadLine().ToCharArray();
            action.DynamicInvoke();
            
        }
    }
    
    class Label : Elements
    {
        private Delegate action;
        private const string leftstandartVisual = "";
        private const string rightstandartVisual = "";
        private const char StandartConectorBafge = '-';
        private const char StandartСalmBadge = '_';
        private const char StandartInvertBadge = ' ';
        public Label(int x, int y, int width, Delegate action, string text, string LeftVisual, string RightVisual, char ConectorBafge, char СalmBadge, char InvertBadge) : base(x, y, width, text, LeftVisual, RightVisual, ConectorBafge, СalmBadge, InvertBadge, false)
        {
            this.action = action;
        }
        public Label(int x, int y, int width, Delegate action, string text, string LeftVisual, string RightVisual) : base(x, y, width, text, LeftVisual, RightVisual, StandartConectorBafge, StandartСalmBadge, StandartInvertBadge, false)
        {
            this.action = action;
        }
        public Label(int x, int y, int width, string text) : base(x, y, width, text, leftstandartVisual, rightstandartVisual, StandartConectorBafge, StandartСalmBadge, StandartInvertBadge, false)
        {
            this.action = null;
        }
        public override string[] render(bool highlight)
        {
            string[] render_label = new string[1];
            string string_render = "";
            int len_label = width;
            if (text.Length > width)
            {
                len_label = text.Length;
            }
            for(int i = 0; i< len_label; i++)
            {
                if (i < text.Length )
                {
                    string_render += text[i];
                }
                else
                {
                    string_render += СalmBadge;
                }
            }
            render_label[0] = string_render;
            return render_label;
        }
        public override void effect()
        {
            

        }

    }

}
