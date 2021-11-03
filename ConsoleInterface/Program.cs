using ConsoleInterface.Classes;
using System;
using System.Collections.Generic;

namespace ConsoleInterface
{
    class Program
    {
        delegate void DelegateElement();
        static UiInterface ui = new UiInterface(40, 150);
        static void Main(string[] args)
        {
            DelegateElement fin = button1;
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
    
   
    
    
    
    
    
    

}
