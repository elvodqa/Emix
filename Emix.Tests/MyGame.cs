using Emix.Graphics.GUI;
using Emix.Windowing;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Emix.Tests
{
    public class MyGame : EmixScene
    {
        private BasicButton newButton;
        private BasicButton loadButton;
        private BasicButton settingsButton;
        private BasicButton exitButton;
        
        
        public MyGame()
        {
            Window = new GameWindow("Emix: Visual Novel Engine");
            DebugInfo = true;
        }
        protected override void Initialize()
        {
            newButton = new BasicButton("Play");
            exitButton = new BasicButton("Exit");
            settingsButton = new BasicButton("Settings");
            loadButton = new BasicButton("Load");
            
            newButton.Position = new Vector2f(20, 300);
            loadButton.Position = new Vector2f(20, 350);
            settingsButton.Position = new Vector2f(20, 400);
            exitButton.Position = new Vector2f(20, 450);
            
            base.Initialize();
        }

        protected override void Update()
        {
            newButton.Draw(Window);
            exitButton.Draw(Window);
            settingsButton.Draw(Window);
            loadButton.Draw(Window);
            
            base.Update();
        }
    }
}