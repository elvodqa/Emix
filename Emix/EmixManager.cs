﻿using System;
using Emix.Windowing;
using SFML.Window;

namespace Emix
{
    public static class EmixManager
    {
        public static void DisposeWindow(GameWindow window)
        {
            window.Close();
        }
        
        public static void ShowRuntimeError(string title, string message)
        {
            Console.WriteLine(  $"{title ?? ""}:\n{message ?? ""}");
        }

        public static void ShowRuntimeError(string? eStackTrace)
        {
            Console.WriteLine(  $"Error:\n{eStackTrace ?? ""}");
        }
    }
}