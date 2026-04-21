using System;


[Serializable]
public class Psychokinesis : Element
{
    public override ElementType ElementType
    {
        get => ElementType.Magic;
    }

    public override string Name
    {
        get => $"{nameof(Psychokinesis)}";
    }
}
