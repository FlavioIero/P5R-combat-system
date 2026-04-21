using System;


[Serializable]
public class Phys : Element
{
    public override ElementType ElementType
    {
        get => ElementType.Physical;
    }

    public override string Name
    {
        get => $"{nameof(Phys)}";
    }
}
