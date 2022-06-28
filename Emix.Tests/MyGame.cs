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

            AddDialog("No matter how many times you play. It's all the same.");
            AddDialog("It would be really, really easy to kill myself right now. But that would mean I don't get to talk to you anymore.");
            
            base.Setup();
        }
    }
}