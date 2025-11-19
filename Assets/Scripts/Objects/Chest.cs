using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

public class Chest : NetworkBehaviour, IInteractuable
{
    [SerializeField] private Transform spawnPlace;
    [SerializeField] private GameObject obj;

    private readonly SyncVar<bool> closed = new(true);

    [SerializeField] private Animator animator;

    [ServerRpc(RequireOwnership = false)]
    public void OpenChest()
    {
        animator.Play("Open");
        

        GameObject objSpawned = Instantiate(obj, spawnPlace.position, Quaternion.identity);

        // Tell FishNet to replicate this object to all clients
        Spawn(objSpawned);

        // Apply physics on the server — this syncs automatically
        if (objSpawned.TryGetComponent(out Rigidbody rb))
        {
            rb.WakeUp();
            rb.AddForce((-transform.forward * 2) + Vector3.up * 7, ForceMode.Impulse);
        }
    }

    public void Hover(PlayerUIManager UIManager)
    {
        UIManager.CanInteract(closed.Value, "Open");
    }

    public void Interact(PlayerManager player)
    {
        if (!closed.Value)
            return;

        closed.Value = false;

        OpenChest();
    }

    private void OnClosedChanged(bool oldValue, bool newValue, bool asServer)
    {
        // You can add logic here for opening animation, sound, etc.
    }
}
