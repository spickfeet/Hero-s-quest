using System;

public interface IWorkStation
{
    public void Cook();
    public void Add(ItemType item);
    public Action OnFinished { get; set; }
}

