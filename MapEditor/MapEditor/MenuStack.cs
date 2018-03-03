using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class MenuStack
    {
        #region Singletone
        public static MenuStack Instance => instance ?? (instance = new MenuStack());
        private static MenuStack instance;

        private MenuStack()
        {
            menus = new Stack<IMenu>();
        }
        #endregion

        private Stack<IMenu> menus;

        public IMenu CurrentMenu => menus.FirstOrDefault();

        public void Push(IMenu menu)
        {
            IMenu lastMenu = menus.FirstOrDefault();
            lastMenu?.Close();

            menus.Push(menu);
            menu.Open();
        }

        public void Pop()
        {
            IMenu popMenu = menus.Pop();
            popMenu.Close();

            IMenu lastMenu = menus.FirstOrDefault();
            lastMenu?.Open();
        }
    }
}
