using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public void CanInteract(bool isInteractable, string interactMode)
    {
        LevelCanvas.Instance.interactableText.gameObject.SetActive(isInteractable);
        LevelCanvas.Instance.interactableText.text = "\"E\" to " + interactMode;
    }
}
