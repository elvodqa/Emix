using SFML.Graphics;
using SFML.System;

namespace Emix.Graphics.Primitives;

public class Rectangle : RectangleShape
{
    public Rectangle(float width, float height) : base(new Vector2f(width, height))
    {
        Position = new Vector2f(0, 0);
    }

    public Rectangle(float width, float height, Color color) : base(new Vector2f(width, height))
    {
        Position = new Vector2f(0, 0);
        FillColor = color;
    }


    public Rectangle(float X, float Y, float width, float height, Color color) : base(new Vector2f(width, height))
    {
        Position = new Vector2f(X, Y);
        FillColor = color;
    }

    public Rectangle(Math.Vector2f position, float width, float height, Color color) : base(new Vector2f(width,
        height))
    {
        Position = new Vector2f(position.X, position.Y);
        FillColor = color;
    }

    public Rectangle(Math.Vector2f position, Math.Vector2f size, Color color) : base(new Vector2f(size.X, size.Y))
    {
        Size = new Vector2f(size.X, size.Y);
        Position = new Vector2f(position.X, position.Y);
        FillColor = color;
    }
}