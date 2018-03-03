using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class UIMenu : IMenu
    {
        private Vector2 position;
        private List<string> UI;

        public void Close()
        {
            
        }

        public void Open()
        {
            
        }

        public void Render()
        {
           
            Console.SetCursorPosition(10, 29);
            //Console.Write("'H'");
            //Console.Write(vertice.GetSymbol());
            //Console.Write($"{vertice.GetSymbol()}");

        }

        public UIMenu()
        {
            Console.SetCursorPosition(2, 29);
            UI = new List<string>
            {
                "Symbol", 
                "FontColor",
                "BackgroundColor\n",
                "Press P to open Tools menu"
            };

            for(int i = 0; i < UI.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(UI[i] + "       "); 
            }

            using (StreamReader readSymbol = new StreamReader("Verticeinfo.txt"))
            {
                string symbol = readSymbol.ReadLine();
                Console.SetCursorPosition(11, 29);
                Console.Write(symbol);
            }

            using (StreamReader readBack = new StreamReader("FontColor.txt"))
            {
                string symbol = readBack.ReadLine();
                Console.SetCursorPosition(26, 29);
                Console.Write(symbol);
            }

            using (StreamReader readBack = new StreamReader("BackColor.txt"))
            {
                string symbol = readBack.ReadLine();
                Console.SetCursorPosition(48, 29);
                Console.Write(symbol);
            }

        }


        
    }
}
