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
        public MyGame()
        {
            DebugInfo = true;
        }

        protected override void Setup()
        {
            Character emir = new Character("Emir", Window);
            SetActiveSpeaker(emir);
            AddDialog("aaaaaaaaaaaa");
            AddDialog("qweqweqwewqewqaaaaaaa");
            
            base.Setup();
        }
    }
}