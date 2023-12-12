using UnityEngine;
using UnityEngine.InputSystem;

public class PL_Player_Interact : MonoBehaviour
{
    [Header("Components")]
    public GameObject objectInFront;
    public GameObject interactionText;
    [SerializeField] private GameObject endGameMenu;

    [Header("Variables")]
    private string _interactible;

    //public void InteractPlayer()
    //{
    //    interactionText.SetActive(true);
    //    if (objectInFront.tag == "interactible")
    //    {
    //        //interagir
    //    }
    //}

    public void OnPlayerInteract(InputAction.CallbackContext context)
    {
        switch (objectInFront.tag)
        {
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
        //endGameMenu.GetComponent<EndMenu>().OnGameOverCheck(true);
        endGameMenu.SetActive(true);
    }
}
