using UnityEngine;

public class PL_Enemy_Collision : MonoBehaviour
{
    private Transform transformEnemy;
    private bool canGoForward, canGoLeft, canGoRight, canGoBack;
    public static PL_Enemy_Collision Instance;
    private bool playerInFront;
    private string[] nametags = new string[9] { "ClosedLockChest", "ClosedChest", "ClosedLockDoor", "ClosedDoor", "Trap", "DesactivatedTrap", "Exit", "wall", "Player"};
    private RaycastHit[] raycastsHit = new RaycastHit[4];
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            print("you have 2 scripts");
            Destroy(this);
        }

        transformEnemy = transform;
        playerInFront = false;
    }
    private void Update()
    {
        CollisionDetectEnemy();
    }

    private void CollisionDetectEnemy()
    {
        canGoForward = canGoBack = canGoLeft = canGoRight = true;
        Debug.DrawRay(transformEnemy.position, transformEnemy.forward, Color.green);
        Debug.DrawRay(transformEnemy.position, transformEnemy.right, Color.blue);
        Debug.DrawRay(transformEnemy.position, -transformEnemy.forward, Color.red);
        Debug.DrawRay(transformEnemy.position, -transformEnemy.right, Color.black);
        foreach (string nametag in nametags)
        {
            if (Physics.Raycast(transformEnemy.position, transformEnemy.forward, out raycastsHit[0], 1)) canGoForward = raycastsHit[0].transform.tag != nametag;
            if (Physics.Raycast(transformEnemy.position, -transformEnemy.right, out raycastsHit[1], 1)) canGoLeft = raycastsHit[1].transform.tag != nametag;
            if (Physics.Raycast(transformEnemy.position, transformEnemy.right, out raycastsHit[2], 1)) canGoRight = raycastsHit[2].transform.tag != nametag;
            if (Physics.Raycast(transformEnemy.position, -transformEnemy.forward, out raycastsHit[3], 1)) canGoBack = raycastsHit[3].transform.tag != nametag;
        }

        print("collision forward : " + canGoForward);
    }
    public bool IsCanGo(string direction)
    {
        if (direction == "forward") return canGoForward;
        else if (direction == "right") return canGoRight;
        else if (direction == "back") return canGoBack;
        else if (direction == "left") return canGoLeft;
        return false;
    }

    public bool IsPlayerInFront()
    {
        return playerInFront;
    }
}
