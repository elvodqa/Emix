using SFML.Graphics;

namespace Emix.Graphics.Primitives;

public class Triangle : CircleShape
{
    /// <summary>
    /// </summary>
    /// <param name="height"></param>
    /// <param name="color"></param>
    public Triangle(float height, Color color) : base(height / 2, 3)
    {
        FillColor = color;
    }

    /// <summary>
    /// </summary>
    /// <param name="height"></param>
    /// <param name="color"></param>
    /// <param name="thickness"></param>
    public Triangle(float height, Color color, float thickness) : base(height / 2, 3)
    {
        FillColor = color;
        OutlineThickness = thickness;
        OutlineColor = color;
    }

    /// <summary>
    /// </summary>
    /// <param name="height"></param>
    /// <param name="color"></param>
    /// <param name="thickness"></param>
    /// <param name="outlineColor"></param>
    public Triangle(float height, Color color, float thickness, Color outlineColor) : base(height / 2, 3)
    {
        FillColor = color;
        OutlineThickness = thickness;
        OutlineColor = outlineColor;
    }

    /// <summary>
    /// </summary>
    /// <param name="height"></param>
    /// <param name="color"></param>
    /// <param name="thickness"></param>
    /// <param name="outlineColor"></param>
    /// <param name="outlineThickness"></param>
    public Triangle(float height, Color color, float thickness, Color outlineColor, float outlineThickness) : base(
        height / 2, 3)
    {
        FillColor = color;
        OutlineThickness = thickness;
        OutlineColor = outlineColor;
        OutlineThickness = outlineThickness;
    }
}