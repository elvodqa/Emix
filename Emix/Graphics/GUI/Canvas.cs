using System.Collections.Generic;
using Emix.Windowing;
using SFML.Graphics;

namespace Emix.Graphics.GUI
{
    public class Canvas : List<Drawable>
    {
        public List<BasicButton> UIButtonLayer { get; set; } = new List<BasicButton>();
        public void Draw(GameWindow window)
        {
            foreach (Drawable element in this)
            {
                element.Draw(window);
            }

            foreach (var uiElement in UIButtonLayer)
            {
                uiElement.Draw(window);
            }
        }
    }
}