using System;


[Serializable]
public class Almighty : Element
{
    public override ElementType ElementType
    {
        get => ElementType.Magic;
    }

    public override string Name
    {
        get => $"{nameof(Almighty)}";
    }
}
