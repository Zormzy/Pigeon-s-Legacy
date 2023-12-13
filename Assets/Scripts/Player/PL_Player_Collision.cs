using System;
using UnityEngine;

public class PL_Player_Collision : MonoBehaviour
{
    [Header("Components")]
    private Transform transformPlayer;
    private PL_Player_Interact _playerInteract;

    [Header("Variables")]
    private bool canGoForward, canGoLeft, canGoRight, canGoBack;
    public static PL_Player_Collision Instance;
    private string[] nametags = new string[9] { "ClosedLockChest", "ClosedChest", "ClosedLockDoor", "ClosedDoor", "Trap", "DesactivatedTrap", "Exit", "wall", "Enemy" };
    private RaycastHit[] raycastsHit = new RaycastHit[4];

    private void Awake()
    {
        transformPlayer = transform;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            print("you have 2 scripts");
            Destroy(this);
        }
        _playerInteract = GetComponent<PL_Player_Interact>();
    }

    private void Update()
    {
        CollisionDetectionPlayer();
    }

    private void CollisionDetectionPlayer()
    {
        canGoForward = canGoBack = canGoLeft = canGoRight = true;
        //Debug.DrawRay(transformPlayer.position, transformPlayer.forward, Color.green);
        //Debug.DrawRay(transformPlayer.position, transformPlayer.right, Color.blue);
        //Debug.DrawRay(transformPlayer.position, -transformPlayer.forward, Color.red);
        //Debug.DrawRay(transformPlayer.position, -transformPlayer.right, Color.black);

        if (Physics.Raycast(transformPlayer.position, transformPlayer.forward, out raycastsHit[0], 1)) canGoForward = !Array.Exists(nametags, element => element == raycastsHit[0].transform.tag);
        if (Physics.Raycast(transformPlayer.position, -transformPlayer.right, out raycastsHit[1], 1)) canGoLeft = !Array.Exists(nametags, element => element == raycastsHit[1].transform.tag);
        if (Physics.Raycast(transformPlayer.position, transformPlayer.right, out raycastsHit[2], 1)) canGoRight = !Array.Exists(nametags, element => element == raycastsHit[2].transform.tag);
        if (Physics.Raycast(transformPlayer.position, -transformPlayer.forward, out raycastsHit[3], 1)) canGoBack = !Array.Exists(nametags, element => element == raycastsHit[3].transform.tag);

        /*foreach (string nametag in nametags)
        {
            if(Physics.Raycast(transformPlayer.position, transformPlayer.forward, out raycastsHit[0], 1)) canGoForward = raycastsHit[0].transform.tag != nametag;
            if (Physics.Raycast(transformPlayer.position, -transformPlayer.right, out raycastsHit[1], 1)) canGoLeft = raycastsHit[1].transform.tag != nametag;
            if (Physics.Raycast(transformPlayer.position, transformPlayer.right, out raycastsHit[2], 1)) canGoRight = raycastsHit[2].transform.tag != nametag;
            if (Physics.Raycast(transformPlayer.position, -transformPlayer.forward, out raycastsHit[3], 1)) canGoBack = raycastsHit[3].transform.tag != nametag;
        }*/

        if (Physics.Raycast(transformPlayer.position, transformPlayer.forward, out raycastsHit[0], 1))
        {
            switch (raycastsHit[0].transform.tag)
            {
                case "ClosedLockChest": break; //si le joueur a une clef, ouvrir le coffre
                case "ClosedChest": break;
                case "ClosedLockDoor": break; //si le joueur a une clef, ouvrir la porte
                case "ClosedDoor":
                    _playerInteract.interactionText.SetActive(true);
                    _playerInteract.objectInFront = raycastsHit[0].transform.gameObject;
                    break;
                case "Trap": break; //proposer de désactiver
                case "DesactivatedTrap": break;
                case "Exit":
                    _playerInteract.interactionText.SetActive(true);
                    _playerInteract.objectInFront = raycastsHit[0].transform.gameObject;
                    break;
                default:
                    _playerInteract.interactionText.SetActive(false); break;
            }
        }
        else
        {
            _playerInteract.interactionText.SetActive(false);
        }
    }

    public bool IsCanGo(Vector3 direction)
    {
        if(direction.normalized == Vector3.forward) return canGoForward;
        else if(direction.normalized == Vector3.right) return canGoRight;
        else if(direction.normalized == Vector3.back) return canGoBack;
        else if(direction.normalized == Vector3.left) return canGoLeft;
        return false;
    }
}