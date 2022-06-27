using Emix.Windowing;
using SFML.Graphics;
using SFML.System;

namespace Emix.Graphics;

public class Drawable : Sprite
{
    /// <summary>
    /// </summary>
    /// <param name="texture"></param>
    public Drawable(Texture texture) : base(texture)
    {
        Position = new Vector2f(0, 0);
    }

    public Drawable()
    {
        Position = new Vector2f(0, 0);
    }

    /*
    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="states"></param>
    public virtual void Draw(RenderTarget target, RenderStates states)
    {
        states.Transform *= Transform;
        target.Draw(this, states);
    }
    */

    public virtual void Draw(RenderTarget target)
    {
        //states.Transform *= Transform;
        base.Draw(target, RenderStates.Default);
    }

    public virtual void Draw(GameWindow target)
    {
        //states.Transform *= Transform;
        base.Draw(target, RenderStates.Default);
    }

    /// <summary>
    ///     Set the width of the drawable
    /// </summary>
    /// <param name="width"></param>
    public void SetWidth(float width)
    {
        Scale = new Vector2f(width / Texture.Size.X, Scale.Y);
    }

    /// <summary>
    ///     Set the height of the drawable
    /// </summary>
    /// <param name="height"></param>
    public void SetHeight(float height)
    {
        Scale = new Vector2f(Scale.X, height / Texture.Size.Y);
    }


    /// <summary>
    ///     Set the positipn of the drawable
    /// </summary>
    /// <param name="position"></param>
    public void SetPosition(Vector2f position)
    {
        Position = position;
    }

    /// <summary>
    ///     Set the position of the drawable
    /// </summary>
    /// <param name="x">X value of the position</param>
    /// <param name="y">Y value of the position</param>
    public void SetPosition(float x, float y)
    {
        Position = new Vector2f(x, y);
    }

    public float GetWidth()
    {
        return Texture.Size.X * Scale.X;
    }

    public float GetHeight()
    {
        return Texture.Size.Y * Scale.Y;
    }
}