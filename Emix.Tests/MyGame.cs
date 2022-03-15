using System;
using System.Collections.Generic;
using Emix.Graphics;
using Emix.Graphics.GUI;
using Emix.Windowing;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Drawable = Emix.Graphics.Drawable;

namespace Emix.Tests
{
    public class MyGame : EmixScene
    {
        private BasicButton playButton;
        private BasicButton loadButton;
        private BasicButton settingsButton;
        private BasicButton exitButton;
        private Canvas mainMenu;
        
        
        public MyGame()
        {
            Window = new GameWindow("Emix: Visual Novel Engine");
            DebugInfo = true;
        }
        protected override void Initialize()
        {
            playButton = new BasicButton("Play");
            exitButton = new BasicButton("Exit");
            settingsButton = new BasicButton("Settings");
            loadButton = new BasicButton("Load");
                
            playButton.Position = new Vector2f(20, 300);
            loadButton.Position = new Vector2f(20, 350);
            settingsButton.Position = new Vector2f(20, 400);
            exitButton.Position = new Vector2f(20, 450);

            playButton.Clicked += (sender, args) =>
            {
                Console.WriteLine("Play Button clicked");
            };
            mainMenu = new Canvas()
            {
                new Drawable(new Texture("Resources/pre-small.png"))
            };
            mainMenu.UIButtonLayer.Add(loadButton);
            mainMenu.UIButtonLayer.Add(playButton);
            mainMenu.UIButtonLayer.Add(settingsButton);
            mainMenu.UIButtonLayer.Add(exitButton);
            
            mainMenu.UIInputBoxLayer.Add(new BasicInputBox("Bruhh", Window));
            
            base.Initialize();
        }
        
        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("New button clicked");
        }

        protected override void Update()
        {
            mainMenu.Draw(Window);
            
            base.Update();
        }
    }
}