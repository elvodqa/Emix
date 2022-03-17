using Emix.Math;

namespace Emix.Graphics
{
    public class Character
    {
        public Character(string name, Drawable sprite)
        {
            Name = name;
            Sprite = sprite;
            Size = new Vector2f(Sprite.GetWidth(), Sprite.GetHeight());
            IsVisible = true;
            IsTalking = false;
            IsTalkingToPlayer = false;
        }

        public string Name { get; set; }
        public Drawable Sprite { get; set; }
        public string Dialogue { get; set; }
        public Vector2f Position { get; set; }
        public Vector2f Size { get; set; }
        public bool IsVisible { get; set; }
        public bool IsTalking { get; set; }
        public bool IsTalkingToPlayer { get; set; }

        public void Say(string dialogue)
        {
            Dialogue = dialogue;
            IsTalking = true;
        }
    }
}