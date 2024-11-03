using System;

public interface IMinigameWorkStation
{
    public void Cook();
    public void Add(ItemType item);
    public Action<ItemType> OnFinished { get; set; }
}

