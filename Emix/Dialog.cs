using Emix.Graphics;

namespace Emix;

public class Dialog
{
    public string Speaker;
    public string Context;

    public Dialog(string context)
    {
        Context = context;
        Speaker = Global.ActiveSpeaker.Name;
    }
}