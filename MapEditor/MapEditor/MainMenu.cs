using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class MainMenu : IMenu
    {
        private const ConsoleColor textColor = ConsoleColor.Green;
        private const ConsoleColor backgroundColor = ConsoleColor.Black;

        private List<string> menuItems;
        private int currentIndex;

        private Dictionary<ConsoleKey, Action> keyProcessors;
        private Dictionary<int, Action> jumpProcessors;

        public MainMenu()
        {
            menuItems = new List<string>
            {
                "Create new level.",
                "Open level.",
                "About.",
                "Exit."
            };

            keyProcessors = new Dictionary<ConsoleKey, Action>
            {
                {ConsoleKey.UpArrow, MoveUp},
                {ConsoleKey.DownArrow, MoveDown},
                {ConsoleKey.Enter, ProcessEnter }
            };

            jumpProcessors = new Dictionary<int, Action>
            {
                {0, CreateLevel },
                {1, OpenLevel },
                {2, ShowAbout },
                {3, Exit }
            };

            Console.CursorVisible = false;
        }

        public void Open()
        {
            Input.OnKeyPressed += ProcessInput;
        }

        public void Close()
        {
            Input.OnKeyPressed -= ProcessInput;
        }

        public void Render()
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.Clear();

            for(int i = 0; i < menuItems.Count; i++)
            {
                Console.ForegroundColor = i != currentIndex ? textColor : backgroundColor;
                Console.BackgroundColor = i != currentIndex ? backgroundColor : textColor;
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
            }

            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
        }

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
            currentIndex = (currentIndex + 1) % menuItems.Count;
        }

        private void MoveUp()
        {
            currentIndex = currentIndex == 0 ? menuItems.Count - 1 : currentIndex - 1;
        }

        private void CreateLevel()
        {
            MenuStack.Instance.Push(new EnterMenu(EnterMenu.Mode.Create));
        }

        private void OpenLevel()
        {
            MenuStack.Instance.Push(new EnterMenu(EnterMenu.Mode.Open));
        }

        private void ShowAbout()
        {
            MenuStack.Instance.Push(new AboutMenu());
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
