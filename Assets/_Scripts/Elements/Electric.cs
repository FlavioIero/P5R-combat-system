using System;


[Serializable]
public class Electric : Element
{
    public override ElementType ElementType
    {
        get => ElementType.Magic;
    }

    public override string Name
    {
        get => $"{nameof(Electric)}";
    }
}
