using ConsoleInterface.Classes;


namespace ConsoleInterface
{

    class Program
    {

        delegate void DelegateElement(); //Делегат для обратотчиков
        static UiInterface ui = new UiInterface(40, 150); // создание Дисплея (Высота, Ширина)
        static void Main(string[] args)
        {
            DelegateElement Function;

            Function = cliced_button;
            Button buttonName = new Button(5, 10, Function, "Привет мир"); // Создание кнопки (x,y,Делегат функции обработчика, текст)

            ui.add(buttonName, "buttonNameString"); //Добавление обьекта на экран
            ui.display();

        }
        static void cliced_button()
        {
            ui.get_element("buttonNameString").text = "Ура я нажал на кнопку".ToCharArray();
        }

    }
    /*
    class Program
    {
        delegate void DelegateElement();
        static UiInterface ui = new UiInterface(40, 150);
        static void Main(string[] args)
        {
            DelegateElement fin;
            fin = button1;
            Button button = new Button(10, 10, 21, fin, "Привет мир", "/|||\\", "\\|||/");
            fin = entry1;
            Entry entry = new Entry(20, 20, 21, fin, "Приве");
            Label label = new Label(10, 5, 0, "Text");
            ui.add(label, "label");
            ui.add(button, "button");
            ui.add(entry, "entry");
            ui.display();

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
    */









}
