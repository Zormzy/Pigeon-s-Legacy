using UnityEngine;

public class PL_Player_Collision : MonoBehaviour
{
    private Transform transformPlayer;
    private bool canGoForward, canGoLeft, canGoRight, canGoBack;
    public static PL_Player_Collision Instance;
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
    }
    private void Update()
    {
        CollisionDetectionPlayer();
    }

    private void CollisionDetectionPlayer()
    {
        Debug.DrawRay(transformPlayer.position, transformPlayer.forward, Color.green);
        if (Physics.Raycast(transformPlayer.position, transformPlayer.forward, out RaycastHit hit, 1))
        {
            canGoForward = false;
            switch (hit.transform.tag)
            {
                case "ClosedLockChest": break; //si le joueur a une clef, ouvrir le coffre
                case "ClosedChest": break; //ouvrir le coffre
                case "ClosedLockDoor": break; //si le joueur a une clef, ouvrir la porte
                case "ClosedDoor": break; //ouvrir la porte
                case "Trap": break; //proposer de désactiver
                case "DesactivatedTrap": break;
                case "Exit": break; // finir le niveau
                default: break;
            }

            canGoLeft = true;
            canGoRight = true;
            canGoBack = true;
        }
        else if (Physics.Raycast(transformPlayer.position, -transformPlayer.right, out RaycastHit hitLeft, 1))
        {
            canGoLeft = false;
            canGoForward = true;
            canGoRight = true;
            canGoBack = true;
        }
        else if (Physics.Raycast(transformPlayer.position, transformPlayer.right, out RaycastHit hitRight, 1))
        {
            canGoRight = false;
            canGoForward = true;
            canGoLeft = true;
            canGoBack = true;
        }
        else if (Physics.Raycast(transformPlayer.position, -transformPlayer.forward, out RaycastHit hitBack, 1))
        {
            canGoBack = false;
            canGoForward = true;
            canGoLeft = true;
            canGoRight = true;
        }
        else
        {
            canGoBack = true;
            canGoForward = true;
            canGoLeft = true;
            canGoRight = true;
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