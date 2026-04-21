using System;


[Serializable]
public class Wind : Element
{
    public override ElementType ElementType
    {
        get => ElementType.Magic;
    }

    public override string Name
    {
        get => $"{nameof(Wind)}";
    }
}
