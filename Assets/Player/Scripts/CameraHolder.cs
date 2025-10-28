using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

public class CameraHolder : NetworkBehaviour
{
    [SerializeField] private Transform cameraHolder;

    // This method will run on the client once this object is spawned.
    public override void OnOwnershipClient(NetworkConnection prevOwner)
    {
        if (Camera.main == null)
            return;

        // If we are the new owner of this object, then take control of the camera by parenting it
        // and moving it to our camera holder.
        if (IsOwner)
        {
            Camera.main.transform.SetPositionAndRotation(cameraHolder.position, cameraHolder.rotation);
            Camera.main.transform.SetParent(cameraHolder);
        }
    }
}
