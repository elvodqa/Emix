using System.Collections.Generic;
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
            DialogSize = new Vector2f(this.window.Size.X - 40, (this.window.Size.X - 40) / 4);
            Background = new RectangleShape(DialogSize);
            Dialog = new Text("", new Font("Resources/arial.ttf"), 20);
            Background.FillColor = Color.Black;
            Background.Position = new Vector2f(20, this.window.Size.Y - (20 + DialogSize.Y));
            Background.OutlineThickness = 5;
            Background.OutlineColor = Color.White;
            
            Name = new Text("Name", new Font("Resources/arial.ttf"), 20);
            Name.Position = new Vector2f(20, this.window.Size.Y - (50 + DialogSize.Y));
            Dialog.DisplayedString = "Deneme deneme 1 2 3";
            Dialog.CharacterSize = 20;
            Dialog.Position = new Vector2f(22, this.window.Size.Y - (20 + DialogSize.Y));
            
            historyButton.Background.Size = new Vector2f(50, 20);
            //historyButton.SetWidth(100);
            historyButton.Text.Position = historyButton.Position;
            historyButton.Text.CharacterSize = 11;
            historyButton.Position = new Vector2f(20 + (Background.Size.X / 2) - 50, this.window.Size.Y - 30);
            saveButton.Background.Size = new Vector2f(50, 20);
            saveButton.Text.Position = saveButton.Position;
            saveButton.Text.CharacterSize = 15;
            saveButton.Position = new Vector2f(historyButton.Position.X + 50, this.window.Size.Y - 30);
            loadButton.Background.Size = new Vector2f(50, 20);
            loadButton.Text.Position = loadButton.Position;
            loadButton.Text.CharacterSize = 15;
            loadButton.Position = new Vector2f(saveButton.Position.X + 50, this.window.Size.Y - 30);
            
            optionList.Add(historyButton);
            optionList.Add(saveButton);
            optionList.Add(loadButton);
            
        }

        public new virtual void Draw()
        {
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