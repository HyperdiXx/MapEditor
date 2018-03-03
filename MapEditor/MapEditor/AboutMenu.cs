using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class AboutMenu : IMenu
    {
        private Dictionary<ConsoleKey, Action> keyProcessors;


        public AboutMenu()
        {
            keyProcessors = new Dictionary<ConsoleKey, Action>
            {{ ConsoleKey.Escape, CloseAbout} };

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
            Console.WriteLine("Map editor.\n2018\n");
            Console.WriteLine("Press ESC to close...");

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

        public void CloseAbout()
        {
            MenuStack.Instance.Pop();
        }
    }
}
