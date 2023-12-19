using UnityEngine;
using UnityEngine.InputSystem;

public class PL_Player_Interact : MonoBehaviour
{
    [Header("Components")]
    public GameObject objectInFront;
    public GameObject interactionText;
    public GameObject chestInFront;
    public int i;
    [SerializeField] private GameObject endGameMenu;
    [SerializeField] private EndMenu endGameMenuManager;

    public void OnPlayerInteract(InputAction.CallbackContext context)
    {
        switch (objectInFront.tag)
        {
            case "ClosedChest": OnPlayerOpenChest(objectInFront); break;
            case "ClosedDoor": OnPlayerOpenDoor(objectInFront); break;
            case "Exit": OnPlayerExit(); break;
        }
        interactionText.SetActive(false);
    }

    public void OnPlayerOpenDoor(GameObject door)
    {
        door.SetActive(false);
    }

    public void OnPlayerExit()
    {
        endGameMenuManager.OnGameOverCheck(true);
        endGameMenu.SetActive(true);
    }
    public void OnPlayerOpenChest(GameObject chest)
    {
        Debug.Log("cpapt gros tqt");
    }
}
