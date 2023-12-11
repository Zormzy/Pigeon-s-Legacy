using UnityEngine;

public class PL_Player_Collision : MonoBehaviour
{
    private Transform transformPlayer;
    private bool canGoForward, canGoLeft, canGoRight, canGoBack;
    public static PL_Player_Collision Instance;
    private string[] nametags = new string[8] { "ClosedLockChest", "ClosedChest", "ClosedLockDoor", "ClosedDoor", "Trap", "DesactivatedTrap", "Exit", "wall" };
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
    }
    private void Update()
    {
        CollisionDetectionPlayer();
    }

    private void CollisionDetectionPlayer()
    {
        canGoForward = canGoBack = canGoLeft = canGoRight = true;
        Debug.DrawRay(transformPlayer.position, transformPlayer.forward, Color.green);
        Debug.DrawRay(transformPlayer.position, transformPlayer.right, Color.blue);
        Debug.DrawRay(transformPlayer.position, -transformPlayer.forward, Color.red);
        Debug.DrawRay(transformPlayer.position, -transformPlayer.right, Color.black);

        foreach (string nametag in nametags)
        {
            if(Physics.Raycast(transformPlayer.position, transformPlayer.forward, out raycastsHit[0], 1)) canGoForward = raycastsHit[0].transform.tag != nametag;
            if (Physics.Raycast(transformPlayer.position, -transformPlayer.right, out raycastsHit[1], 1)) canGoLeft = raycastsHit[1].transform.tag != nametag;
            if (Physics.Raycast(transformPlayer.position, transformPlayer.right, out raycastsHit[2], 1)) canGoRight = raycastsHit[2].transform.tag != nametag;
            if (Physics.Raycast(transformPlayer.position, -transformPlayer.forward, out raycastsHit[3], 1)) canGoBack = raycastsHit[3].transform.tag != nametag;
        }
        if (Physics.Raycast(transformPlayer.position, transformPlayer.forward, out raycastsHit[0], 1))
        {
            switch (raycastsHit[0].transform.tag)
            {
                case "ClosedLockChest": break; //si le joueur a une clef, ouvrir le coffre
                case "ClosedChest": break;
                case "ClosedLockDoor": break; //si le joueur a une clef, ouvrir la porte
                case "ClosedDoor": break; //ouvrir la porte
                case "Trap": break; //proposer de désactiver
                case "DesactivatedTrap": break;
                case "Exit": break; // finir le niveau
                default: break;
            }
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