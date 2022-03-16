using Emix.Windowing;
using SFML.Graphics;
using SFML.System;

namespace Emix.Graphics.GUI
{
    public class BasicText : Drawable
    {
        public Vector2f Position
        {
            get;
            set;
        }

        public Text Text
        {
            get;
            set;
        }
        
        public BasicText(string text)
        {
            Text = new Text(text, new Font("Resources/arial.ttf"));
            Text.Position = new Vector2f(0, 0);
            Text.CharacterSize = 12;
        }

        public new virtual void Draw(GameWindow window)
        {   
            Text.Draw(window, RenderStates.Default);
        }
        
    }
}