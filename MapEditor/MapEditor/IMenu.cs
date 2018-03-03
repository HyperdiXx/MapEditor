using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    interface IMenu
    {
        void Open();
        void Render();
        void Close();
    }
}
