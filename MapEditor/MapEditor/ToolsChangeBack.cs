using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class ToolsChangeBack : IMenu
    {
        private Dictionary<ConsoleKey, Action> keyProcessors;
        private string color;
        private ConsoleColor col;
        public ToolsChangeBack()
        {
            keyProcessors = new Dictionary<ConsoleKey, Action>
            {
                {ConsoleKey.Escape, GoBack}
            };

        }

        public void Close()
        {
            Input.OnKeyPressed -= ProcessInput;
        }

        public void Open()
        {
            Input.OnKeyPressed += ProcessInput;
        }

        public void Render()
        {
            Console.Clear();

            Console.WriteLine("Enter new Backcolor (From Upper letter): ");
            color = Console.ReadLine();
            switch (color)
            {
                case "Black":
                    col = ConsoleColor.Black;
                    break;
                case "Blue":
                    col = ConsoleColor.Blue;
                    break;
                case "Red":
                    col = ConsoleColor.Red;
                    break;
                default:
                    Console.WriteLine("Unknown color((");
                    break;
            }
            Console.WriteLine($"New Background Color: {color}");


            using (StreamWriter writes = new StreamWriter("BackColor.txt"))
            {
                writes.WriteLine(col);
            }
        }


        private void ProcessInput(ConsoleKey key)
        {
            try
            {
                keyProcessors[key]();
            }
            catch (KeyNotFoundException)
            {

            }
        }

        private void GoBack()
        {
            MenuStack.Instance.Pop();
        }
    }
}
