using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PL_Player_Interact : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector] public GameObject objectInFront;
    public GameObject interactionText;
    private GameObject endGameMenu;
    private EndMenu endGameMenuManager;
    [HideInInspector] public GameObject notAvailableText;
    private bool hasKey = false;

    private void Start()
    {
        endGameMenu = GameObject.FindGameObjectWithTag("EndMenu");
        notAvailableText = GameObject.FindGameObjectWithTag("NotAvailable");
        endGameMenuManager = endGameMenu.GetComponent<EndMenu>();
    }

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
    public void OnPlayerOpenChest(GameObject chest)
    {
        Debug.Log("cpapt gros tqt");
    }
}
