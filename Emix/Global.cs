using System.Collections.Generic;
using Emix.Graphics;
using Emix.Windowing;

namespace Emix;

internal class Global
{
    internal static List<Character> Characters = new List<Character>();
    internal static Character ActiveSpeaker = null;
    internal static List<Dialog> Dialogs = new List<Dialog>();
    internal static GameWindow Window = new GameWindow("Emix: Visual Novel Engine");
}