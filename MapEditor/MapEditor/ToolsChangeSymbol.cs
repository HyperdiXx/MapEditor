using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class ToolsChangeSymbol : IMenu
    {
        //private List<Vertice> vertices;
        public char symbol;
        private Dictionary<ConsoleKey, Action> keyProcessors;
        public ToolsChangeSymbol()
        {
            keyProcessors = new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.Escape, GoBack}
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

            Console.WriteLine("Enter new symbol: ");
            symbol = Console.ReadKey().KeyChar;
            Console.WriteLine($"\nNew Symbol: {symbol}");
            using (StreamWriter writes = new StreamWriter("Verticeinfo.txt"))
            {
                writes.WriteLine(symbol);
            }
        }

        private void GoBack()
        {  
            MenuStack.Instance.Pop();
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


    }
}
