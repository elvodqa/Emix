using System;
using Emix.Windowing;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Emix.Graphics.GUI
{
    public class BasicInputBox : UIElement
    {
        private readonly RectangleShape _background;
        private readonly Color _backgroundColor;
        private readonly Color _hoverColor;
        private readonly Color _pressedColor;
        private readonly Color _textColor;
        private readonly Clock clock;
        private bool _isPressed;
        public bool Focus;

        public Text Text;
        public GameWindow Window;

        public BasicInputBox(string text, GameWindow Window)
        {
            font = new Font("Resources/arial.ttf");
            Text = new Text(text, font);
            Text.CharacterSize = 20;
            Text.Color = Color.White;
            Text.Position = new Vector2f(10, 10);
            clock = new Clock();
            this.Window = Window;
            _background = new RectangleShape();
            _background.FillColor = Color.Black;
            _background.Position = Position;
            _background.Size = new Vector2f(Text.GetGlobalBounds().Width + 20, Text.GetGlobalBounds().Height + 20);
            _background.OutlineColor = Color.White;
            _background.OutlineThickness = 2;
            _backgroundColor = Color.Black;
            _textColor = Color.White;
            _hoverColor = new Color(192, 192, 192);
            _pressedColor = new Color(128, 128, 128);
            Window.TextEntered += Window_TextEntered;
        }

        public Font font { get; set; }

        public event EventHandler<EventArgs> Clicked;

        private void Window_TextEntered(object sender, TextEventArgs e)
        {
            if (Focus)
            {
                if (e.Unicode == "\b" && Text.DisplayedString.Length > 0)
                    Text.DisplayedString = Text.DisplayedString.Remove(Text.DisplayedString.Length - 1);
                else
                    Text.DisplayedString += e.Unicode;
            }
        }

        public new virtual void Draw(GameWindow window)
        {
            var dt = clock.Restart();
            //states.Transform *= Transform;
            var mousePosition = Mouse.GetPosition(window);
            window.Draw(_background, RenderStates.Default);
            window.Draw(Text, RenderStates.Default);
            _background.Position = Position;
            Text.Position = new Vector2f(Position.X + 10, Position.Y + 10);

            if (!_background.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y) &&
                Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Focus = false;
                Console.WriteLine("Focus False");
            }


            if (_background.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    _isPressed = true;
                    _background.FillColor = _pressedColor;
                    Focus = true;
                    Console.WriteLine("Focus True");
                    OnClick();
                }
                else
                {
                    _isPressed = false;

                    _background.FillColor = _hoverColor;
                }
            }
            else
            {
                _isPressed = false;
                _background.FillColor = _hoverColor;
                _background.FillColor = _backgroundColor;
            }

            _background.Size = new Vector2f(Text.GetGlobalBounds().Width + 20, Text.GetGlobalBounds().Height + 20);
        }

        private void OnClick()
        {
            Clicked?.Invoke(this, new EventArgs());
        }
    }
}