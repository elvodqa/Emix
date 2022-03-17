namespace Emix.Math
{
    public struct Vector2<T>
    {
        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }

        public T X { get; }
        public T Y { get; }
    }

    public struct Vector2f
    {
        public Vector2f(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; }
        public float Y { get; }
    }

    public struct Vector2i
    {
        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }

    public struct Vector2d
    {
        public Vector2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }
    }
}