using System;
using Emix.Windowing;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Emix.Graphics.GUI
{
    public class BasicButton : UIElement
    {
        public event EventHandler<EventArgs> Clicked;

        private readonly Text _text;
        private readonly RectangleShape _background;
        private readonly Color _backgroundColor;
        private readonly Color _textColor;
        private readonly Color _hoverColor;
        private readonly Color _pressedColor;
        public Font font { get; set; }
        private bool _isPressed;

        
        
        public BasicButton(string text) 
            : base(new Texture("Resources/button.png"))
        {
            font = new Font(("Resources/arial.ttf"));
            _text = new Text(text, font);
            _text.CharacterSize = 20;
            _text.Color = Color.White;
            _text.Position = new Vector2f(10, 10);
            

            _background = new RectangleShape();
            _background.FillColor = Color.Black;
            _background.Position = Position;
            _background.Size = new Vector2f(_text.GetGlobalBounds().Width + 20, _text.GetGlobalBounds().Height + 20);
            _background.OutlineColor = Color.White;
            _background.OutlineThickness = 2;
            _backgroundColor = Color.Black;
            _textColor = Color.White;
            _hoverColor = new Color(192, 192, 192);
            _pressedColor = new Color(128, 128, 128);;
        }
        
        public BasicButton(string text, 
            Color backgroundColor,  
            Color textColor, 
            Color hoverColor, 
            Color pressedColor) 
            : base(new Texture("Resources/button.png"))
        {
            _text = new Text(text, font);
            _text.CharacterSize = 20;
            _text.Color = textColor;
            _text.Position = new Vector2f(10, 10);
            font = new Font(("Resources/arial.ttf"));

            _background = new RectangleShape();
            _background.FillColor = backgroundColor;
            _background.Position = Position;
            _background.Size = new Vector2f(_text.GetGlobalBounds().Width + 20, _text.GetGlobalBounds().Height + 20);
            
            _backgroundColor = backgroundColor;
            _textColor = textColor;
            _hoverColor = hoverColor;
            _pressedColor = pressedColor;
        }
        
        
        public BasicButton(string text, Font font,
            Color backgroundColor,  
            Color textColor, 
            Color hoverColor, 
            Color pressedColor) 
            : base(new Texture("Resources/button.png"))
        {
            _text = new Text(text, font);
            _text.CharacterSize = 20;
            _text.Color = textColor;
            _text.Position = new Vector2f(10, 10);
            //font = new Font(("Resources/arial.ttf"));

            _background = new RectangleShape();
            _background.FillColor = backgroundColor;
            _background.Position = Position;
            _background.Size = new Vector2f(_text.GetGlobalBounds().Width + 20, _text.GetGlobalBounds().Height + 20);
            
            _backgroundColor = backgroundColor;
            _textColor = textColor;
            _hoverColor = hoverColor;
            _pressedColor = pressedColor;
        }
        
        
        public new virtual void Draw(GameWindow window)
        {
            //states.Transform *= Transform;
            var mousePosition = Mouse.GetPosition(window);
            window.Draw(_background, RenderStates.Default);
            window.Draw(_text, RenderStates.Default);
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
            
        }

        public new virtual void Draw(RenderTarget target, RenderStates states, Vector2f mousePosition)
        {
            //states.Transform *= Transform;
            
            target.Draw(_background, states);
            target.Draw(_text, states);
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
            
        }

        public void OnClick()
        {
            Clicked?.Invoke(this, new EventArgs());
        }
    }
}