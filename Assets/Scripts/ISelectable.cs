using System;

public interface ISelectable
{
    public void Select();

    public void Deselect();

    public static Action<bool> OnSelected;
}
