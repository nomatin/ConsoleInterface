using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface.Classes
{
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
        public Button(int x, int y, int width, Delegate action, string text) : base(x, y, width, text, leftstandartVisual, rightstandartVisual, StandartConectorBafge, StandartСalmBadge, StandartInvertBadge, true)
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
                        else if (i == LeftVisual.Length / 2 && (j > (len_but - text.Length) / 2 && j < (len_but - text.Length) / 2 + text.Length + 1))
                        {
                            if (text[j - (len_but - text.Length) / 2 - 1] == ' ')
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
}
