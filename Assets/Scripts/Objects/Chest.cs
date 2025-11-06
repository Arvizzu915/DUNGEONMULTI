using FishNet.Object;
using UnityEngine;

public class Chest : NetworkBehaviour, 
{

    [ServerRpc]
    public void OpenChest()
    {

    }
}
