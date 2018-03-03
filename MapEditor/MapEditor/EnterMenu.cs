using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MapEditor
{
    class EnterMenu : IMenu
    {
        public enum Mode
        {
            Create, Open
        }

        private Mode mode;
        public EnterMenu(Mode mode)
        {
            this.mode = mode;
        }

        public void Close()
        {

        }

        public void Open()
        {

        }

        public void Render()
        {
            Console.Clear();

            Console.WriteLine("Enter file name:");
            string fileName = Input.ReadLine() + ".txt";
            Console.WriteLine($"Filename {fileName}");

            FileInfo file = new FileInfo(fileName);
            if(mode == Mode.Create)
            {
                if (file.Exists)
                {
                    Console.WriteLine("File already exists.");
                }
                else
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
                    {
                        MenuStack.Instance.Pop();
                    }
                    MenuStack.Instance.Push(new EditorMenu(fileName));
                }
            }
            else
            {
                if (file.Exists)
                {
                    MenuStack.Instance.Pop();
                    MenuStack.Instance.Push(new EditorMenu(fileName));
                }
                else
                {
                    Console.WriteLine("File doesn't exist.");
                }
            }
        }
    }
}
