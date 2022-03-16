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

        public Text Text;
        public RectangleShape Background;
        private readonly Color _backgroundColor;
        private readonly Color _textColor;
        private readonly Color _hoverColor;
        private readonly Color _pressedColor;
        public Font Font { get; set; }
        private bool _isPressed;

        
        
        public BasicButton(string text) 
            : base()
        {
            Font = new Font(("Resources/arial.ttf"));
            Text = new Text(text, Font);
            Text.CharacterSize = 20;
            Text.FillColor = Color.White;
            Text.Position = new Vector2f(10, 10);
            

            Background = new RectangleShape();
            Background.FillColor = Color.Black;
            Background.Position = Position;
            Background.Size = new Vector2f(Text.GetGlobalBounds().Width + 20, Text.GetGlobalBounds().Height + 20);
            Background.OutlineColor = Color.White;
            Background.OutlineThickness = 2;
            _backgroundColor = Color.Black;
            _textColor = Color.White;
            _hoverColor = new Color(192, 192, 192);
            _pressedColor = new Color(128, 128, 128);
        }
        
        public BasicButton(string text, 
            Color backgroundColor,  
            Color textColor, 
            Color hoverColor, 
            Color pressedColor) 
            : base()
        {
            Text = new Text(text, Font);
            Text.CharacterSize = 20;
            Text.Color = textColor;
            Text.Position = new Vector2f(10, 10);
            Font = new Font(("Resources/arial.ttf"));

            Background = new RectangleShape();
            Background.FillColor = backgroundColor;
            Background.Position = Position;
            Background.Size = new Vector2f(Text.GetGlobalBounds().Width + 20, Text.GetGlobalBounds().Height + 20);
            
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
            : base()
        {
            Text = new Text(text, font);
            Text.CharacterSize = 20;
            Text.Color = textColor;
            Text.Position = new Vector2f(10, 10);
            //font = new Font(("Resources/arial.ttf"));

            Background = new RectangleShape();
            Background.FillColor = backgroundColor;
            Background.Position = Position;
            Background.Size = new Vector2f(Text.GetGlobalBounds().Width + 20, Text.GetGlobalBounds().Height + 20);
            
            _backgroundColor = backgroundColor;
            _textColor = textColor;
            _hoverColor = hoverColor;
            _pressedColor = pressedColor;
        }
        
        
        
        public new virtual void Draw(GameWindow window)
        {
            //states.Transform *= Transform;
            var mousePosition = Mouse.GetPosition(window);
            window.Draw(Background, RenderStates.Default);
            window.Draw(Text, RenderStates.Default);
            Background.Position = Position;
            Text.Position = new Vector2f(Position.X + 10, Position.Y + 10);
            
            
            if (Background.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    _isPressed = true;
                    Background.FillColor = _pressedColor;
                }
                else
                {
                    _isPressed = false;
                    Background.FillColor = _hoverColor;
                }
            }
            else
            {
                _isPressed = false;
                Background.FillColor = _backgroundColor;
            }
            
            if (_isPressed)
            {
                OnClick();
                _isPressed = false;
            }
           
        }

        public new virtual void Draw(RenderTarget target, RenderStates states, Vector2f mousePosition)
        {
            //states.Transform *= Transform;
            
            target.Draw(Background, states);
            target.Draw(Text, states);
            Background.Position = Position;
            Text.Position = new Vector2f(Position.X + 10, Position.Y + 10);

            if (Background.GetGlobalBounds().Contains(mousePosition.X, mousePosition.Y))
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    _isPressed = true;
                    Background.FillColor = _pressedColor;
                }
                else
                {
                    _isPressed = false;
                    Background.FillColor = _hoverColor;
                }
            }
            else
            {
                _isPressed = false;
                Background.FillColor = _backgroundColor;
            }

            if (_isPressed)
            {
                OnClick();
                _isPressed = false;
            }
            
        }

        private void OnClick()
        {
            Clicked?.Invoke(this, new EventArgs());
        }
    }
}