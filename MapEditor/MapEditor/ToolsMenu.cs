using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{

    class ToolsMenu : IMenu
    {
        private const ConsoleColor textColorTools = ConsoleColor.Green;
        private const ConsoleColor backgroundColorTools = ConsoleColor.Black;

        private List<string> toolsItems;
        private int currentIndex;

        private Dictionary<ConsoleKey, Action> keyProcessors;
        private Dictionary<int, Action> jumpProcessors;

        public ToolsMenu()
        {
            toolsItems = new List<string>
            {
                "Symbol",
                "Fontcolor",
                "Backgroundcolor",
                "Collision",
                "Exit"
            };

            keyProcessors = new Dictionary<ConsoleKey, Action>
            {
                {ConsoleKey.UpArrow, MoveUp},
                {ConsoleKey.DownArrow, MoveDown},
                {ConsoleKey.Enter, ProcessEnter }
            };

            jumpProcessors = new Dictionary<int, Action>
            {
                {0,  ChangeSymbol},
                {1,  ChangeFont},
                {2,  ChangeBack},
                {3,  ChangeCollision},
                {4, GoBack}
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
            Console.ForegroundColor = textColorTools;
            Console.BackgroundColor = backgroundColorTools;
            Console.Clear();

            for (int i = 0; i < toolsItems.Count; i++)
            {
                Console.ForegroundColor = i != currentIndex ? textColorTools : backgroundColorTools;
                Console.BackgroundColor = i != currentIndex ? backgroundColorTools  : textColorTools;
                Console.WriteLine($"{i + 1}. {toolsItems[i]}");
            }

            Console.ForegroundColor = textColorTools;
            Console.BackgroundColor = backgroundColorTools;

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

        private void ProcessEnter()
        {
            try
            {
                jumpProcessors[currentIndex]();
            }
            catch (KeyNotFoundException)
            {

            }
        }

        private void MoveDown()
        {
            currentIndex = (currentIndex + 1) % toolsItems.Count;
        }

        private void MoveUp()
        {
            currentIndex = currentIndex == 0 ? toolsItems.Count - 1 : currentIndex - 1;
        }


        private void ChangeSymbol()
        {
            MenuStack.Instance.Push(new ToolsChangeSymbol());
        }

        private void ChangeFont()
        {
            MenuStack.Instance.Push(new ToolsChangeFont());
        }

        private void ChangeBack()
        {
            MenuStack.Instance.Push(new ToolsChangeBack());
        }

        private void ChangeCollision()
        {

        }

        private void GoBack()
        {
            MenuStack.Instance.Pop();
        }
    }
}
