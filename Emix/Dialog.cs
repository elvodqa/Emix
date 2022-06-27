namespace Emix;

public class Dialog
{
    public string Context;
    public string Speaker;

    public Dialog(string context)
    {
        Context = context;
        Speaker = Global.ActiveSpeaker.Name;
    }
}