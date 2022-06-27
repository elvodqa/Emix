using Emix.Math;
using Emix.Windowing;
using SFML.Graphics;

namespace Emix.Graphics;

public class Character
{
    public Character(string name, GameWindow Window)
    {
        Name = name;
        Sprite = new Drawable(new Texture("Resources/football_player.png"));
        Sprite.SetWidth(250);
        Sprite.SetHeight(600);
        Size = new Vector2f(Sprite.GetWidth(), Sprite.GetHeight());
        IsVisible = false;
        IsTalking = false;
        this.Window = Window;
    }

    public string Name { get; set; }
    public Drawable Sprite { get; set; }
    public string Dialogue { get; set; }
    public Vector2f Position { get; set; }
    public Vector2f Size { get; set; }
    public bool IsVisible { get; set; }
    public bool IsTalking { get; set; }
    public GameWindow Window { get; }

    public void Say(string dialogue)
    {
        Dialogue = dialogue;
        IsTalking = true;
    }

    public virtual void Draw()
    {
        Sprite.Position = new SFML.System.Vector2f(70, 80);
        Sprite.Draw(Window);
    }
}