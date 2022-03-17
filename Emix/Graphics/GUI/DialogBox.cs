using System.Collections.Generic;
using System.Numerics;
using Emix.Graphics.Primitives;
using Emix.Windowing;
using SFML.Graphics;
using SFML.System;

namespace Emix.Graphics.GUI
{
    public class DialogBox : Drawable
    {
        
        public RectangleShape Background { get; private set; }
        public Text Name { get; private set; }
        public Text Dialog { get; private set; }
        private List<BasicButton> optionList = new List<BasicButton>();
        private BasicButton historyButton = new BasicButton("History");
        private BasicButton saveButton = new BasicButton("Save");
        private BasicButton loadButton = new BasicButton("Load");
        private GameWindow window;
        private Vector2f DialogSize;
        public DialogBox(GameWindow window)
        {
            this.window = window;
            DialogSize = new Vector2f(this.window.Size.X - 40, (this.window.Size.X - 40) / 6.5f);
            Background = new RectangleShape(DialogSize);
            Dialog = new Text("", new Font("Resources/arial.ttf"), 20);
            Background.FillColor = Color.Black;
            Background.Position = new Vector2f(20, this.window.Size.Y - (30 + DialogSize.Y));
            Background.OutlineThickness = 5;
            Background.OutlineColor = Color.White;
            
            Name = new Text("Name", new Font("Resources/arial.ttf"), 20);
            Name.Position = new Vector2f(20, this.window.Size.Y - (60 + DialogSize.Y));
            Dialog.DisplayedString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vitae fermentum erat\n Phasellus porta auctor massa vitae placerat. Aliquam et enim in\n dolor sodales egestas. Aliquam a elementum elit. \n Aenean lacinia scelerisque viverra. Curabitur aliquam ligula vitae massa\n egestas, eget vestibulum justo accumsan. Donec ac ligula ac nisi lobortis fini";
            Dialog.CharacterSize = 20;
            Dialog.Position = new Vector2f(22, this.window.Size.Y - (30 + DialogSize.Y));
            
            historyButton.Background.Size = new Vector2f(50, 15);
            historyButton.Text.CharacterSize = 11;
            historyButton.Position = new Vector2f(20 + (Background.Size.X / 2) - 50, this.window.Size.Y - 20);
           
            saveButton.Background.Size = new Vector2f(50, 15);
            saveButton.Text.CharacterSize = 11;
            saveButton.Position = new Vector2f(historyButton.Position.X + 50, this.window.Size.Y - 20);
            saveButton.Text.Position = saveButton.Position;
            
            loadButton.Background.Size = new Vector2f(50, 15);
            loadButton.Text.CharacterSize = 11;
            loadButton.Position = new Vector2f(saveButton.Position.X + 50, this.window.Size.Y - 20);
            loadButton.Text.Position = loadButton.Position;
            
            optionList.Add(historyButton);
            optionList.Add(saveButton);
            optionList.Add(loadButton);
            
        }

        public new virtual void Draw()
        {
            historyButton.Background.Size = new Vector2f(50, 15);
            historyButton.Text.CharacterSize = 11;
            historyButton.Position = new Vector2f(20 + (Background.Size.X / 2) - 50, this.window.Size.Y - 20);
            historyButton.Text.Position = new Vector2f(historyButton.Position.X + 5, historyButton.Position.Y + 2);
           
            saveButton.Background.Size = new Vector2f(50, 15);
            saveButton.Text.CharacterSize = 11;
            saveButton.Position = new Vector2f(historyButton.Position.X + 50, this.window.Size.Y - 20);
            saveButton.Text.Position = new Vector2f(saveButton.Position.X + 7, saveButton.Position.Y + 1);
            
            loadButton.Background.Size = new Vector2f(50, 15);
            loadButton.Text.CharacterSize = 11;
            loadButton.Position = new Vector2f(saveButton.Position.X + 50, this.window.Size.Y - 20);
            loadButton.Text.Position = new Vector2f(loadButton.Position.X + 8, loadButton.Position.Y + 1);
            
            Background.Draw(window, RenderStates.Default);
            Name.Draw(window, RenderStates.Default);
            Dialog.Draw(window, RenderStates.Default);
            //Dialog.Draw(window, RenderStates.Default);
            foreach (BasicButton button in optionList)
            {
                button.Draw(window);
            }
            
        }

    }
}