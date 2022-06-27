using System.Collections.Generic;
using Emix.Windowing;

namespace Emix.Graphics.GUI;

public class Canvas : List<Drawable>
{
    public List<BasicButton> UIButtonLayer { get; set; } = new();
    public List<BasicInputBox> UIInputBoxLayer { get; set; } = new();
    public List<BasicText> UIBasicTextLayer { get; set; } = new();

    public void Draw(GameWindow window)
    {
        foreach (var element in this) element.Draw(window);

        foreach (var uiElement in UIButtonLayer) uiElement.Draw(window);

        foreach (var uiElement in UIInputBoxLayer) uiElement.Draw(window);

        foreach (var uiElement in UIBasicTextLayer) uiElement.Draw(window);
    }
}