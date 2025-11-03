using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Object;
using System.Linq;
using UnityEngine;

public class BootstrapNetworkManager : NetworkBehaviour
{
    private static BootstrapNetworkManager instance;

    private void Awake()
    {
        instance = this;

    }

    public static void ChangeNetworkScene(string sceneName, string[] scenesToClose)
    {
        instance.CloseScenes(scenesToClose);

        SceneLoadData sld = new SceneLoadData(sceneName);

        NetworkConnection[] conns = instance.ServerManager.Clients.Values.ToArray();
        instance.SceneManager.LoadConnectionScenes(conns, sld);

    }

    [ServerRpc(RequireOwnership = false)]
    void CloseScenes(string[] scenesToClose)
    {
        CloseScenecesObserver(scenesToClose);
    }

    [ObserversRpc]
    void CloseScenecesObserver(string[] scenesToClose)
    {
        foreach (var scene in scenesToClose)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene);
        }
    }
}
