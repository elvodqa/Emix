using System.Collections.Generic;
using Emix.Windowing;
using SFML.Graphics;

namespace Emix.Graphics.GUI
{
    public class Canvas : List<Drawable>
    {
        public List<BasicButton> UIButtonLayer { get; set; } = new List<BasicButton>();
        public List<BasicInputBox> UIInputBoxLayer { get; set; } = new List<BasicInputBox>();
        public List<BasicText> UIBasicTextLayer { get; set; } = new List<BasicText>();
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
            
            foreach (var uiElement in UIInputBoxLayer)
            {
                uiElement.Draw(window);
            }
            
            foreach (var uiElement in UIBasicTextLayer)
            {
                uiElement.Draw(window);
            }
        }
    }
}