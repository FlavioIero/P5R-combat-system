using System;


[Serializable]
public class Nuclear : Element
{
    public override ElementType ElementType
    {
        get => ElementType.Magic;
    }

    public override string Name
    {
        get => $"{nameof(Nuclear)}";
    }
}
