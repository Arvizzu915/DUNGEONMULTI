using UnityEngine;

public interface IInteractuable
{
    public abstract void Interact(PlayerManager player);

    public abstract void Hover(PlayerUIManager UIManager);
}
