﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuStack.Instance.Push(new MainMenu());
            
            do
            {
                MenuStack.Instance.CurrentMenu.Render();
                Input.Update();
            } while (true);
        }
    }
}
