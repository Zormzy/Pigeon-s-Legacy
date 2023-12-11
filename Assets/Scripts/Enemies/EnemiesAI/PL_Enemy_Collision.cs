using UnityEngine;

public class PL_Enemy_Collision : MonoBehaviour
{
    private Transform transformEnemy;
    private bool canGoForward, canGoLeft, canGoRight, canGoBack;
    public static PL_Enemy_Collision Instance;
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
    }
    private void Update()
    {
        CollisionDetectEnemy();
    }

    private void CollisionDetectEnemy()
    {
        Debug.DrawRay(transformEnemy.position, transformEnemy.forward, Color.green);
        if (Physics.Raycast(transformEnemy.position, transformEnemy.forward, out RaycastHit hit, 1))
        {
            canGoForward = false;
            canGoRight = true;
            canGoLeft = true;
            canGoBack = true;
        }
        else if (Physics.Raycast(transformEnemy.position, -transformEnemy.right, out RaycastHit hitLeft, 1))
        {
            canGoLeft = false;
            canGoForward = true;
            canGoRight = true;
            canGoBack = true;
        }
        else if (Physics.Raycast(transformEnemy.position, transformEnemy.right, out RaycastHit hitRight, 1))
        {
            canGoRight = false;
            canGoForward = true;
            canGoLeft = true;
            canGoBack = true;
        }
        else if (Physics.Raycast(transformEnemy.position, -transformEnemy.forward, out RaycastHit hitBack, 1))
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
        if (direction.normalized == Vector3.forward) return canGoForward;
        else if (direction.normalized == Vector3.right) return canGoRight;
        else if (direction.normalized == Vector3.back) return canGoBack;
        else if (direction.normalized == Vector3.left) return canGoLeft;
        return false;
    }
}
