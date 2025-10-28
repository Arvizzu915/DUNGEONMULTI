using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCubeCreator : NetworkBehaviour
{
    [SerializeField] InputManager inputManager;

    public NetworkObject cubePrefab;

    public override void OnStartClient()
    {
        inputManager.inputs.Playing.Attack.started += OnFire;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        inputManager.inputs.Playing.Attack.started -= OnFire;
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        SpawnCube();
    }

    // We are using a ServerRpc here because the Server needs to do all network object spawning.
    [ServerRpc]
    private void SpawnCube()
    {
        NetworkObject obj = Instantiate(cubePrefab, transform.position, Quaternion.identity);

        obj.GetComponent<SyncMaterialColor>().color.Value = Random.ColorHSV();
        Spawn(obj); // NetworkBehaviour shortcut for ServerManager.Spawn(obj);
    }
}    