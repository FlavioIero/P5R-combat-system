using System;


[Serializable]
public enum ElementType
{
    Physical = 0,
    Magic = 1
}

public interface IElement
{
    public ElementType ElementType { get; }
    public abstract string Name { get; }
}