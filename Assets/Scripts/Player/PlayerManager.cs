using UnityEngine;
using FishNet;
using FishNet.Object;

public class PlayerManager : NetworkBehaviour
{
    public PlayerUIManager PlayerUIManager;
    public PlayerCombat playerCombat;

    public GameObject canvas;
    public LevelCanvas levelCanvas;

    public override void OnStartClient()
    {
        if (!IsOwner) return;

        // Create the local HUD
        GameObject hud = Instantiate(canvas);
        levelCanvas = hud.GetComponent<LevelCanvas>();

        PlayerUIManager.SetManager(this);
    }
}
