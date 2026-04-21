using System;


[Serializable]
public class Fire : Element
{
    public override ElementType ElementType
    {
        get => ElementType.Magic;
    }

    public override string Name
    {
        get => $"{nameof(Fire)}";
    }
}
