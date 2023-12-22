using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PL_Player_Interact : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector] public GameObject objectInFront;
    public GameObject interactionText;
    public GameObject hasNotKey;
    [SerializeField] private GameObject endGameMenu;
    [SerializeField] private EndMenu endGameMenuManager;
    private bool hasKey = false;
    private SpawnLoot _spawnLoot;
    private AudioSource audioSource;
    [SerializeField] private AudioClip DoorOpened;
    [SerializeField] private AudioClip chestOpened;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnPlayerInteract(InputAction.CallbackContext context)
    {
        if (objectInFront)
        { 
            switch (objectInFront.tag)
            {
                case "ClosedChest": 
                    _spawnLoot = objectInFront.GetComponent<SpawnLoot>();
                    OnPlayerOpenChest(objectInFront);
                    audioSource.clip = chestOpened; audioSource.Play();
                    break;
                case "ClosedDoor": audioSource.clip = DoorOpened; audioSource.Play(); OnPlayerOpenDoor(objectInFront); objectInFront.tag = "Door"; break;
                case "ClosedLockDoor" : if (hasKey) { audioSource.clip = DoorOpened; audioSource.Play(); OnPlayerOpenDoor(objectInFront); objectInFront.tag = "Door"; } break;
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
        endGameMenu.SetActive(true);
        if (endGameMenu.activeSelf)
            endGameMenuManager.OnGameOverCheck(true);
    }
    public void OnPlayerOpenChest(GameObject chest)
    {
        Debug.Log("chest opened");
        _spawnLoot.spawnLoot = true;
    }
}
