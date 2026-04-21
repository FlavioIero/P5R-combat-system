using System;


[Serializable]
public class Bless : Element
{
    public override ElementType ElementType
    {
        get => ElementType.Magic;
    }

    public override string Name
    {
        get => $"{nameof(Bless)}";
    }
}
