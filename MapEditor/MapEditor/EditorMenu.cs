using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MapEditor
{
    class EditorMenu : IMenu
    {
        public List<Vertice> vertices;

        private string filename;
        public VerticeFactory fact;
        private char[] s;
        private string FontColor;
        private string BackColor;

        public EditorMenu(string filename)
        {
            this.filename = filename;
            vertices = new List<Vertice>();
            keyProcessors = new Dictionary<ConsoleKey, Action>
            {
                {ConsoleKey.UpArrow, MoveUp },
                {ConsoleKey.DownArrow, MoveDown },
                {ConsoleKey.LeftArrow, MoveLeft },
                {ConsoleKey.RightArrow, MoveRight },
                {ConsoleKey.Spacebar, TogglePen },
                {ConsoleKey.Escape, SaveFile },
                {ConsoleKey.P, ToolsMenu}
            };
            ParseFile(filename);
        }

        public void Close()
        {
            Console.CursorVisible = false;
            Input.OnKeyPressed -= ProcessInput;
        }

        public void Open()
        {
            Console.CursorVisible = true;
            Input.OnKeyPressed += ProcessInput;
        }

        public void Render()
        {
            Console.Clear();
            Console.SetCursorPosition(currentPosition.X, currentPosition.Y);

            UIMenu menu = new UIMenu();

            menu.Render();

            if (isPenDown && !vertices.Any(vertice => vertice.Position == currentPosition))
            {
               
                using (StreamReader readSymbol = new StreamReader("Verticeinfo.txt"))
                {
                    string symbol = readSymbol.ReadLine();
                    s = symbol.ToCharArray();
                }

                using (StreamReader readSymbol = new StreamReader("FontColor.txt"))
                {
                    FontColor = readSymbol.ReadLine();
                }

                using (StreamReader readSymbol = new StreamReader("BackColor.txt"))
                {
                    BackColor = readSymbol.ReadLine();
                }
               
                fact = new VerticeFactory();
                vertices.Add(fact.CreateVertice(currentPosition, s[0], (ConsoleColor)Enum.Parse(typeof(ConsoleColor), FontColor), (ConsoleColor)Enum.Parse(typeof(ConsoleColor), BackColor)));
            }

            for (int i = 0; i < vertices.Count; i++)
            {
                Vertice vertice = vertices[i];
                Console.SetCursorPosition(vertice.Position.X, vertice.Position.Y);
                Console.ForegroundColor = vertice.FontColor;
                Console.BackgroundColor = vertice.BackgroundColor;
                Console.Write(vertice.Symbol);
            }
            
            Console.SetCursorPosition(currentPosition.X, currentPosition.Y);
        }

        #region Parser

        private void ParseFile(string filename)
        {
            string mapLine;
            using (StreamReader reader = new StreamReader(filename))
            {
                while ((mapLine = reader.ReadLine()) != null)
                {
                    if (mapLine.StartsWith("#"))
                        continue;

                    try
                    {
                        vertices.Add(ParseLine(mapLine));
                    }
                    catch (FormatException)
                    {

                    }
                }
            }
        }

        private Vertice ParseLine(string line)
        {
            Vertice vertice = new Vertice();

            string[] args = line.Split(';'); // Splitting file line by ';' symbol.

            vertice.Symbol = char.Parse(args[0]);
            vertice.Position = new Vector2(int.Parse(args[1]), int.Parse(args[2]));
            vertice.FontColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[3]);
            vertice.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), args[4]);
            vertice.Collision = int.Parse(args[5]) == 1;

            return vertice;
        }

        #endregion

        private Dictionary<ConsoleKey, Action> keyProcessors;

        private void ProcessInput(ConsoleKey key)
        {
            try
            {
                keyProcessors[key]();
            }
            catch(KeyNotFoundException)
            {

            }
        }

        private bool isPenDown;
        private void TogglePen()
        {
            isPenDown = !isPenDown;
        }

        private void ToolsMenu()
        {
            MenuStack.Instance.Push(new ToolsMenu());
        }

        private Vector2 currentPosition;
        private void MoveUp()
        {
            currentPosition += Vector2.up;
        }

        private void MoveDown()
        {
            currentPosition += Vector2.down;
        }

        private void MoveLeft()
        {
            currentPosition += Vector2.left;
        }

        private void MoveRight()
        {
            currentPosition += Vector2.right;
        }

        private void SaveFile()
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                fs.Seek(0, SeekOrigin.Begin);
                for(int i = 0; i < vertices.Count; i++)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(vertices[i].ToString() + "\n");
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            MenuStack.Instance.Pop();
        }

        public void ShowUI()
        {
            for(int i =0; i < vertices.Count; i++)
            {
                Vertice vertice = vertices[i];
                Console.SetCursorPosition(vertice.Position.X, vertice.Position.Y);
                Console.ForegroundColor = vertice.GetUIFontColor();
                Console.BackgroundColor = vertice.GetUIBackColor();
                Console.Write(vertice.Symbol);
            }


        }



    }
}
