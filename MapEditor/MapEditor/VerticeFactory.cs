using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class VerticeFactory
    {
        public Vertice vertice;

        public Vertice CreateVertice(Vector2 pos, char symbol, ConsoleColor font, ConsoleColor back)
        {
            vertice = new Vertice();
            vertice.Symbol = symbol;
            vertice.Position = pos;
            vertice.Collision = true;
            vertice.FontColor = font;
            vertice.BackgroundColor = back;
            return vertice;
        }

        
    }
}
