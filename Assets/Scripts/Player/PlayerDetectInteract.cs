using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDetectInteract : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    private IInteractuable currentInteractable = null;

    private void OnEnable()
    {
        //InputManager.Instance.inputs.Playing.Interact.performed += Interact;
    }

    private void OnDisable()
    {
        //InputManager.Instance.inputs.Playing.Interact.performed -= Interact;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 15f))
        {
            if (hit.transform.TryGetComponent(out IInteractuable interactable))
            {
                currentInteractable = interactable;
                interactable.Hover(playerManager.PlayerUIManager);
            }
            else
            {
                currentInteractable = null;
                playerManager.PlayerUIManager.CanInteract(false, "");
            }
        }
        else
        {
            currentInteractable = null;
            playerManager.PlayerUIManager.CanInteract(false, "");
        }

        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }

    private void Interact(InputAction.CallbackContext ctx)
    {
        currentInteractable.Interact();
    }
}
