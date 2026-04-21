using System;


[Serializable]
public class Gun : Element
{
    public override ElementType ElementType
    {
        get => ElementType.Physical;
    }

    public override string Name
    {
        get => $"{nameof(Gun)}";
    }
}
