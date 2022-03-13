using System;
using System.Numerics;
using Emix.Graphics.GUI;
using Emix.Graphics.Primitives;
using Emix.Math;
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
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Emix");
            Triangle triangle = new Triangle(180, Color.Blue);
            BasicButton button = new BasicButton("SUKISUKISI", 
                new Font("Resources/arial.ttf"), 
                Color.Cyan, 
                Color.Green, 
                Color.Magenta, 
                Color.Red);

            button.Position = new Vector2f(400, 400);
            
            window.Closed += (sender, e) => window.Close();
            while (window.IsOpen)
            {

                button.Update(new Vector2f(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y));
               
                window.DispatchEvents();
                window.Clear();
                button.Draw(window, RenderStates.Default);
                triangle.Draw(window, RenderStates.Default);
                window.Display();
            }
            
            
            ;
        }
    }
}