using System;
using SFML.Graphics;
using SFML.System;

namespace Emix.Graphics.Primitives
{
    public class Line : RectangleShape  
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1">X coordinate of first position</param>
        /// <param name="y1">Y coordinate of first position</param>
        /// <param name="x2">X coordinate of second position</param>
        /// <param name="y2">Y coordinate of second position</param>
        /// <param name="color">Color</param>
        /// <param name="thickness">Thickness</param>
        public Line(float x1, float y1, float x2, float y2, Color color, float thickness)
        {
            Position = new Vector2f(x1, y1);
            Size = new Vector2f(x2 - x1, y2 - y1);
            FillColor = color;
            OutlineThickness = thickness;
            Rotation = (float)System.Math.Atan2(y2 - y1, x2 - x1);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1">First position</param>
        /// <param name="v2">Second position</param>
        /// <param name="color">Color</param>
        /// <param name="thickness">Thickness</param>
        public Line(Vector2f v1, Vector2f v2, Color color, float thickness)
        {
            Position = new Vector2f(v1.X, v1.Y);
            Size = new Vector2f(v2.X - v1.X, v2.Y - v1.Y);
            FillColor = color;
            OutlineThickness = thickness;
            Rotation = (float)System.Math.Atan2(v2.Y - v1.Y, v2.X - v1.X);
        }
        
        /*
        public new virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(this, states);
        }
        */
    }
}