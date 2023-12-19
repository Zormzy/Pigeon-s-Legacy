using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PL_Player_Interact : MonoBehaviour
{
    [Header("Components")]
    public GameObject objectInFront;
    public GameObject interactionText;
    [SerializeField] private GameObject endGameMenu;
    [SerializeField] private EndMenu endGameMenuManager;
    public GameObject notAvailableText;
    private bool hasKey = false;


    public void OnPlayerInteract(InputAction.CallbackContext context)
    {
        if (objectInFront)
        {
            switch (objectInFront.tag)
            {
                case "ClosedDoor": OnPlayerOpenDoor(objectInFront); break;
                case "ClosedLockedDoor" : if (hasKey) OnPlayerOpenDoor(objectInFront); break;
                case "Exit": OnPlayerExit(); break;
            }
        }
        interactionText.SetActive(false);
    }

    public void OnPlayerOpenDoor(GameObject door)
    {
        door.SetActive(false);
    }

    public void Key(bool has)
    {
        hasKey = has;
    }

    public bool HasKey()
    {
        return hasKey;
    }

    public void OnPlayerExit()
    {
        endGameMenuManager.OnGameOverCheck(true);
        endGameMenu.SetActive(true);
    }
}
