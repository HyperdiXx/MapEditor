using System;

namespace MapEditor
{
    /// <summary>
    /// Contains vertice info.
    /// </summary>
    public struct Vertice
    {
        public char Symbol;
        public Vector2 Position;
        public ConsoleColor FontColor;
        public const ConsoleColor UIFont = ConsoleColor.Green;
        public ConsoleColor BackgroundColor;
        public const ConsoleColor UIBack = ConsoleColor.Black;
        public bool Collision;

        public override string ToString()
        {
            return $"{Symbol};{Position.X};{Position.Y};{FontColor};{BackgroundColor};{(Collision ? 1 : 0)}";
        }

        public char GetSymbol()
        {
            return Symbol;
        }

        public Vector2 GetPosition()
        {
            return Position;
        }

        public ConsoleColor GetFontcolor()
        {
            return FontColor;
        }

        public ConsoleColor GetUIFontColor()
        {
            return UIFont;
        }

        public ConsoleColor GetUIBackColor()
        {
            return UIBack;
        }

        public ConsoleColor GetBackcolor()
        {
            return BackgroundColor;
        }


    }
}