using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PL_Player_Interact : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector] public GameObject objectInFront;
    public GameObject interactionText;
    [SerializeField] private GameObject endGameMenu;
    private EndMenu endGameMenuManager;
    private bool hasKey = false;
    private SpawnLoot _spawnLoot;

    private void Start()
    {
        endGameMenuManager = endGameMenu.GetComponent<EndMenu>();
    }

    public void OnPlayerInteract(InputAction.CallbackContext context)
    {
        if (objectInFront)
        { 
            switch (objectInFront.tag)
            {
                case "ClosedChest": 
                    _spawnLoot = objectInFront.GetComponent<SpawnLoot>();
                    OnPlayerOpenChest(objectInFront); break;
                case "ClosedDoor": OnPlayerOpenDoor(objectInFront); break;
                case "ClosedLockedDoor" : if (hasKey) OnPlayerOpenDoor(objectInFront); break;
                case "Exit": OnPlayerExit(); break;
                default:break;
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
        _spawnLoot.spawnLoot = true;
       // Debug.Log("cpapt gros tqt");
    }
}
