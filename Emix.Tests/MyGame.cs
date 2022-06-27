using Emix.Graphics;

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
            SetActiveSpeaker(emir);
            AddDialog("hmm...............");
            AddDialog("Hello Wazzup homie");
            base.Setup();
        }
    }
}