using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface.Classes
{
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
        public Elements(int x, int y, int width, string text, string LeftVisual, string RightVisual, char ConectorBafge, char СalmBadge, char InvertBadge, bool activ)
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
}
