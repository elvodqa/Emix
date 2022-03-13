using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Emix.Graphics.GUI
{
    public class BasicButton : Drawable
    {
        public event EventHandler<EventArgs> Clicked;

        private readonly Text _text;
        private readonly RectangleShape _background;
        private readonly Color _backgroundColor;
        private readonly Color _textColor;
        private readonly Color _hoverColor;
        private readonly Color _pressedColor;
        private bool _isPressed;

        public BasicButton(string text, Font font, Color backgroundColor, Color textColor, Color hoverColor, Color pressedColor) 
            : base(new Texture("Resources/button.png"))
        {
            _text = new Text(text, font);
            _text.CharacterSize = 20;
            _text.Color = textColor;
            _text.Position = new Vector2f(10, 10);

            _background = new RectangleShape();
            _background.FillColor = backgroundColor;
            _background.Position = Position;
            _background.Size = new Vector2f(_text.GetGlobalBounds().Width + 20, _text.GetGlobalBounds().Height + 20);
            
            _backgroundColor = backgroundColor;
            _textColor = textColor;
            _hoverColor = hoverColor;
            _pressedColor = pressedColor;
        }

        public void Update(Vector2f mousePosition)
        {
            _background.Position = Position;
            _text.Position = new Vector2f(Position.X + 10, Position.Y + 10);
            
            
            if (_background.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    _isPressed = true;
                    _background.FillColor = _pressedColor;
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
                _background.FillColor = _backgroundColor;
            }
            
            Console.WriteLine(mousePosition.X + " " +mousePosition.Y);
        }

        public new virtual void Draw(RenderTarget target, RenderStates states)
        {
            //states.Transform *= Transform;
            
            target.Draw(_background, states);
            target.Draw(_text, states);
        }

        public void OnClick()
        {
            Clicked?.Invoke(this, new EventArgs());
        }
    }
}