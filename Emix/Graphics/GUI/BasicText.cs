using Emix.Windowing;
using SFML.Graphics;
using SFML.System;

namespace Emix.Graphics.GUI
{
    public class BasicText : Drawable
    {
        public BasicText(string text)
        {
            Text = new Text(text, new Font("Resources/arial.ttf"));
            Text.Position = new Vector2f(0, 0);
            Text.CharacterSize = Size;
        }

        public Vector2f Position { get; set; }

        public uint Size { get; set; } = 12;
        public Text Text { get; set; }

        public new virtual void Draw(GameWindow window)
        {
            Text.Draw(window, RenderStates.Default);
        }
    }
}