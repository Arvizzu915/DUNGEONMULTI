using UnityEngine;
using FishNet;
using FishNet.Object;

public class ObjectManager : NetworkBehaviour, IInteractuable
{
    [SerializeField] WeaponSO weaponSO;

    public void Hover(PlayerUIManager UIManager)
    {
        UIManager.CanInteract(true, "Equip");
    }

    public void Interact(PlayerManager player)
    {
        weaponSO.GetEquipped(player);
        gameObject.SetActive(false);
    }
}
