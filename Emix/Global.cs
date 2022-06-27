using System.Collections.Generic;
using Emix.Graphics;
using Emix.Windowing;

namespace Emix;

internal class Global
{
    internal static List<Character> Characters = new();
    internal static Character ActiveSpeaker = null;
    internal static List<Dialog> Dialogs = new();
    internal static GameWindow Window = new("Emix: Visual Novel Engine");
}