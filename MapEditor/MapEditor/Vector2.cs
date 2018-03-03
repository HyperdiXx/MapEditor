namespace MapEditor
{
    /// <summary>
    /// Contains 2 positions: X and Y.
    /// </summary>
    public struct Vector2
    {
        public int X;
        public int Y;

        public static Vector2 zero => new Vector2(0, 0);
        public static Vector2 up => new Vector2(0, -1);
        public static Vector2 down => new Vector2(0, 1);
        public static Vector2 right => new Vector2(1, 0);
        public static Vector2 left => new Vector2(-1, 0);

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            v1.X += v2.X;
            v1.Y += v2.Y;
            return v1;
        }
    }
}