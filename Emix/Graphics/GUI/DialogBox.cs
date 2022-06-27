using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Emix.Windowing;
using SFML.Graphics;
using SFML.System;

namespace Emix.Graphics.GUI;

public class DialogBox : Drawable
{
    private readonly Vector2f DialogSize;
    private readonly BasicButton historyButton = new("History");
    private readonly BasicButton loadButton = new("Load");
    private readonly List<BasicButton> optionList = new();
    private readonly BasicButton saveButton = new("Save");
    private readonly GameWindow window;
    private int currentDigit;

    private Time delta_time = Time.FromMilliseconds(100);
    private StringBuilder displayBuilder;

    private Time elapsed_time;
    private int maxDigit;
    private readonly Timer myTimer = new();
    private string originalText = "";
    private Clock r;
    private bool UpdatingText;

    public DialogBox()
    {
        window = Global.Window;
        DialogSize = new Vector2f(window.Size.X - 40, (window.Size.X - 40) / 6.5f);
        Background = new RectangleShape(DialogSize);
        Dialog = new Text("", new Font("Resources/arial.ttf"), 20);
        Background.FillColor = Color.Black;
        Background.Position = new Vector2f(20, window.Size.Y - (30 + DialogSize.Y));
        Background.OutlineThickness = 5;
        Background.OutlineColor = Color.White;

        Name = new Text("", new Font("Resources/arial.ttf"), 20);
        Name.Position = new Vector2f(20, window.Size.Y - (60 + DialogSize.Y));
        Dialog.DisplayedString = "";
        Dialog.CharacterSize = 20;
        Dialog.Position = new Vector2f(22, window.Size.Y - (30 + DialogSize.Y));

        historyButton.Background.Size = new Vector2f(50, 15);
        historyButton.Text.CharacterSize = 11;
        historyButton.Position = new Vector2f(Background.Size.X / 2 - 30, window.Size.Y - 20);

        saveButton.Background.Size = new Vector2f(50, 15);
        saveButton.Text.CharacterSize = 11;
        saveButton.Position = new Vector2f(historyButton.Position.X + 50, window.Size.Y - 20);
        saveButton.Text.Position = saveButton.Position;

        loadButton.Background.Size = new Vector2f(50, 15);
        loadButton.Text.CharacterSize = 11;
        loadButton.Position = new Vector2f(saveButton.Position.X + 50, window.Size.Y - 20);
        loadButton.Text.Position = loadButton.Position;

        optionList.Add(historyButton);
        optionList.Add(saveButton);
        optionList.Add(loadButton);
    }

    public RectangleShape Background { get; }
    public Text Name { get; set; }
    public Text Dialog { get; }

    public virtual void Draw()
    {
        historyButton.Background.Size = new Vector2f(50, 15);
        historyButton.Text.CharacterSize = 11;
        historyButton.Position = new Vector2f(20 + (Background.Size.X / 2 - 55), window.Size.Y - 20);
        historyButton.Text.Position = new Vector2f(historyButton.Position.X + 8, historyButton.Position.Y + 2);

        saveButton.Background.Size = new Vector2f(50, 15);
        saveButton.Text.CharacterSize = 11;
        saveButton.Position = new Vector2f(historyButton.Position.X + 55, window.Size.Y - 20);
        saveButton.Text.Position = new Vector2f(saveButton.Position.X + 10, saveButton.Position.Y + 1);

        loadButton.Background.Size = new Vector2f(50, 15);
        loadButton.Text.CharacterSize = 11;
        loadButton.Position = new Vector2f(saveButton.Position.X + 55, window.Size.Y - 20);
        loadButton.Text.Position = new Vector2f(loadButton.Position.X + 12, loadButton.Position.Y + 1);

        Background.Draw(window, RenderStates.Default);
        Name.Draw(window, RenderStates.Default);

        if (UpdatingText)
        {
            myTimer.Start();
            if (displayBuilder.ToString() == originalText) UpdatingText = false;
        }

        Dialog.Draw(window, RenderStates.Default);

        foreach (var button in optionList) button.Draw(window);
    }

    public void ChangeText(string newDialog)
    {
        Dialog.DisplayedString = "";
        originalText = newDialog;
        displayBuilder = new StringBuilder(new string(' ', originalText.Length));
        currentDigit = 0;
        maxDigit = originalText.Length;
        myTimer.Enabled = true;
        myTimer.Interval = 50;

        myTimer.Elapsed += (sender, eventArgs) =>
        {
            displayBuilder[currentDigit] = originalText.ToCharArray()[currentDigit];
            currentDigit++;
            Console.WriteLine(displayBuilder.ToString());
            Dialog.DisplayedString = displayBuilder.ToString();
        };

        UpdatingText = true;
    }
}