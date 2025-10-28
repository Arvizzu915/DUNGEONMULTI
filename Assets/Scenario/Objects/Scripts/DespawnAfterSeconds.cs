using FishNet.Object;
using System.Collections;
using UnityEngine;

public class DespawnAfterSeconds : NetworkBehaviour
{
    public float secondsBeforeDespawn = 3f;

    public override void OnStartServer()
    {
        StartCoroutine(DespawnObjectAfterSeconds());
    }

    private IEnumerator DespawnObjectAfterSeconds()
    {
        yield return new WaitForSeconds(secondsBeforeDespawn);

        Despawn(); // NetworkBehaviour shortcut for ServerManager.Despawn(gameObject);
    }

}
