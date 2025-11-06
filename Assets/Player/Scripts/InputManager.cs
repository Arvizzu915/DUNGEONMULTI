using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public PlayerInput inputs;

    private void Awake()
    {
        Instance = this;

        inputs = new PlayerInput();

        inputs.Playing.Enable();
    }
}
