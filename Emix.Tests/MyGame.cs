using Emix.Graphics;
using SFML.Graphics;
using Drawable = Emix.Graphics.Drawable;

namespace Emix.Tests
{
    public class MyGame : EmixScene
    {
        public MyGame()
        {
            DebugInfo = true;
        }

        protected override void Setup()
        {
            Character emir = new Character("Emir", Window);
            emir.States["normal"] = new Drawable(new Texture("Resources/football_player.png"));
            emir.ChangeState("normal");
            SetActiveSpeaker(emir);
            AddDialog("hmm...............");
            AddDialog("Hello Wazzup homie");
            base.Setup();
        }
    }
}