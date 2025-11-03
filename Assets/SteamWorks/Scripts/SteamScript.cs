using UnityEngine;
using Steamworks;
using UnityEngine.Events;

public class SteamScript : MonoBehaviour
{
    [Header("Initialized")]
    public UnityEvent onSteamInitialized;

    protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;

    private void OnEnable()
    {
        if (SteamManager.Initialized)
        {
            m_GameOverlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);

            string playerName = SteamFriends.GetPersonaName();
            CSteamID playerId = SteamUser.GetSteamID();

            Debug.Log($"[Steam] Connection started.");
            Debug.Log($"[Steam] Player Name: {playerName}");
            Debug.Log($"[Steam] SteamID: {playerId}");

            onSteamInitialized?.Invoke();
        }
    }

    private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
    {
        if (pCallback.m_bActive != 0)
        {
            Debug.Log("Steam Overlay has been activated");
        }
        else
        {
            Debug.Log("Steam Overlay has been closed");
        }
    }
}
