using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface.Classes
{
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
        public Label(int x, int y, string text) : base(x, y, 0, text, leftstandartVisual, rightstandartVisual, StandartConectorBafge, StandartСalmBadge, StandartInvertBadge, false)
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
            for (int i = 0; i < len_label; i++)
            {
                if (i < text.Length)
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
