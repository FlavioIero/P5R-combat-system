using System;


[Serializable]
public class Ice : Element
{
    public override ElementType ElementType
    {
        get => ElementType.Magic;
    }

    public override string Name
    {
        get => $"{nameof(Ice)}";
    }
}
