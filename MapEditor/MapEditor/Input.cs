using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    static class Input
    {
        public delegate void InputKeyHandler(ConsoleKey key);
        public static event InputKeyHandler OnKeyPressed;

        private static bool updated;
        public static ConsoleKey Update()
        {
            if(updated)
            {
                updated = false;
                return ConsoleKey.End;
            }

            ConsoleKey key = Console.ReadKey(true).Key;
            /*
             * if(OnKeyPressed != null)
             *     OnKeyPressed(key);
             */
            OnKeyPressed?.Invoke(key);
            return key;
        }

        public static string ReadLine()
        {
            updated = true;
            return Console.ReadLine();
        }
    }
}
