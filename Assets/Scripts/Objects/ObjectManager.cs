using UnityEngine;
using FishNet;
using FishNet.Object;

public class ObjectManager : NetworkBehaviour, IInteractuable
{
    public void Hover(PlayerUIManager UIManager)
    {
        UIManager.CanInteract(true, "Equip");
    }

    public void Interact(PlayerManager player)
    {
        
    }
}
