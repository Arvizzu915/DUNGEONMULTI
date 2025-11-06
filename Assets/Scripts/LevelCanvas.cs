using TMPro;
using UnityEngine;

public class LevelCanvas : MonoBehaviour
{
    public static LevelCanvas Instance;

    public GameObject HUDPanel;
    public TextMeshProUGUI interactableText;

    private void Awake()
    {
        Instance = this;
    }
}
