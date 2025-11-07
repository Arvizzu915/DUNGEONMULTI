using FishNet.Object;
using UnityEngine;

public class Chest : NetworkBehaviour, IInteractuable
{
    [SerializeField] private GameObject obj;

    private bool closed = true;

    [ServerRpc(RequireOwnership = false)]
    public void OpenChest()
    {
        GameObject objSpawned = Instantiate(obj, transform.position, transform.rotation);
        Rigidbody objRb = objSpawned.GetComponent<Rigidbody>();
        objRb.AddForce(Vector3.up * 7, ForceMode.Impulse);
    }

    public void Hover(PlayerUIManager UIManager)
    {
        UIManager.CanInteract(true, "Open");
    }

    public void Interact()
    {
        

        if (closed)
        {
            closed = false;
            OpenChest();
        }
        
    }
}
