using System;
using System.Numerics;
using Emix.Graphics.Primitives;
using Emix.Math;
using SFML.Graphics;
using SFML.Window;

namespace Emix.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Emix");
            Triangle triangle = new Triangle(180, Color.Blue);
            window.Closed += (sender, e) => window.Close();
            while (window.IsOpen)
            {
                
                window.DispatchEvents();
                window.Clear();
                triangle.Draw(window, RenderStates.Default);
                window.Display();
            }
            
            
            ;
        }
    }
}