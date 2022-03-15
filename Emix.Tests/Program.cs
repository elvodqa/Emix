using System;
using System.Numerics;
using Emix.Graphics.GUI;
using Emix.Graphics.Primitives;
using Emix.Math;
using Emix.Windowing;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Vector2f = SFML.System.Vector2f;

namespace Emix.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (MyGame game = new MyGame())
            {
                game.Run();
            }
            
            
        }
    }
}