using System.Collections.Generic;
using Emix.Windowing;
using SFML.Graphics;

namespace Emix.Graphics.GUI
{
    public class Canvas : List<Drawable>
    {
        public void Draw(GameWindow window)
        {
            foreach (Drawable element in this)
            {
                if (window != null) element.Draw(window, RenderStates.Default);
            }
        }
    }
}