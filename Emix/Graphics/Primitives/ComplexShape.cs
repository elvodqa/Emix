using Emix.Math;
using SFML.Graphics;
using Vector2f = SFML.System.Vector2f;

namespace Emix.Graphics.Primitives;

public class ComplexShape : ConvexShape
{
    /// <summary>
    /// </summary>
    /// <param name="pointCount">number of vertex points the shape will have</param>
    /// <param name="points">array of vertex positions</param>
    public ComplexShape(uint pointCount, Vector2i[] points) : base(pointCount)
    {
        for (var i = pointCount - 1; i < pointCount; i++) SetPoint(i, new Vector2f(points[i].X, points[i].Y));
    }
}