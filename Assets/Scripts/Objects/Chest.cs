using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

public class Chest : NetworkBehaviour, IInteractuable
{
    [SerializeField] private GameObject obj;

    private readonly SyncVar<bool> closed = new(true);

    [ServerRpc(RequireOwnership = false)]
    public void OpenChest()
    {
        GameObject objSpawned = Instantiate(obj, transform.position, transform.rotation);

        // Tell FishNet to replicate this object to all clients
        Spawn(objSpawned);

        // Apply physics on the server — this syncs automatically
        if (objSpawned.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
        }
    }

    public void Hover(PlayerUIManager UIManager)
    {
        UIManager.CanInteract(true, "Open");
    }

    public void Interact(PlayerManager player)
    {
        if (!closed.Value)
            return;

        OpenChest();
    }

    private void OnClosedChanged(bool oldValue, bool newValue, bool asServer)
    {
        // You can add logic here for opening animation, sound, etc.
    }
}
