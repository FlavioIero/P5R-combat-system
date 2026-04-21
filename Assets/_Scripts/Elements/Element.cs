using System;


[Serializable]
public abstract class Element : IElement
{
    public abstract ElementType ElementType { get; }
    public abstract string Name { get; }
}