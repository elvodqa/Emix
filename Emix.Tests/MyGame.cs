using System;
using System.Collections;
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
        private DialogBox _dialogBox;
        private BasicButton exitButton;
        private BasicButton loadButton;
        private Canvas mainMenu;
        private BasicButton playButton;
        private BasicButton settingsButton;
        public Character emir;

        private string[] dialogs = new[]
        {
            "Glad to see you didn't run away on us. Hahaha!",
            "Nah, don't worry.",
            "This might be a little strange for me, but I at least keep my word."
        };

        private int currentDia = 0;

        public MyGame()
        {
            Window = new GameWindow("Emix: Visual Novel Engine");
            DebugInfo = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            playButton = new BasicButton("Play");
            exitButton = new BasicButton("Exit");
            settingsButton = new BasicButton("Settings");
            loadButton = new BasicButton("Load");

            playButton.Position = new Vector2f(20, 300);
            loadButton.Position = new Vector2f(20, 350);
            settingsButton.Position = new Vector2f(20, 400);
            exitButton.Position = new Vector2f(20, 450);

            playButton.Clicked += (sender, args) => { Console.WriteLine("Play Button clicked"); };

            mainMenu = new Canvas
            {
                new(new Texture("Resources/pre-small.png"))
            };
            mainMenu.UIButtonLayer.Add(loadButton);
            mainMenu.UIButtonLayer.Add(playButton);
            mainMenu.UIButtonLayer.Add(settingsButton);
            mainMenu.UIButtonLayer.Add(exitButton);
            var bruhTextBox = new BasicInputBox("1ST", Window);
            var bruhTextBox2 = new BasicInputBox("2ND", Window);
            var enterYourName = new BasicText("Enter your name");
            enterYourName.Text.CharacterSize = 20;
            enterYourName.Text.Position = new Vector2f(20, 250);
            enterYourName.Text.DisplayedString = "Username: ";
            bruhTextBox.Position = new Vector2f(140, 250);
            bruhTextBox2.Position = new Vector2f(400, 250);
            mainMenu.UIInputBoxLayer.Add(bruhTextBox);
            mainMenu.UIInputBoxLayer.Add(bruhTextBox2);
            mainMenu.UIBasicTextLayer.Add(enterYourName);
            _dialogBox = new DialogBox(Window);
            emir = new Character("Emir", Window);
            Window.KeyPressed += NewButton_Clicked;

        }


        private void NewButton_Clicked(object sender, KeyEventArgs arg)
        {
            if (arg.Code == Keyboard.Key.Space)
            {
                _dialogBox.ChangeText(dialogs[currentDia]);
                currentDia += 1;
            }
        }

        protected override void Update()
        {
            //mainMenu.Draw(Window);
            emir.Draw();
            _dialogBox.Draw();
            
            base.Update();
        }
    }
}