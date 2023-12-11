using UnityEngine;

public class PL_Enemy_Movement : MonoBehaviour
{
    private Transform transformEnemy;
    private float moveTimer;
    private float rotateTimer;
    private Vector3 moveTarget;
    private Quaternion rotationTarget;
    private float rotation;
    private bool move = true;
    private bool rotate = false;
    private Quaternion lookOnLook = Quaternion.identity;
    private PL_Enemy_Collision enemyCollision;
    [SerializeField] private float cooldownMoveTime;
    [SerializeField] private Transform transformPlayer;

    private void Awake()
    {
        transformEnemy = transform;
        moveTimer = 0;
        rotateTimer = 0;
        rotation = 0;
        rotationTarget = transformEnemy.rotation;
        moveTarget = transformEnemy.position;
        rotate = true;
        enemyCollision = GetComponent<PL_Enemy_Collision>();
    }

    private void Update()
    {
        if (moveTimer > 0)
            moveTimer -= Time.deltaTime;
        if (rotateTimer > 0)
            rotateTimer -= Time.deltaTime;
        MoveEnemy();
        RotateEnemy();
    }

    private void MoveEnemy()
    {
        /*if (!(Mathf.Abs(transformPlayer.position.x - transformEnemy.position.x) <= .01f ||
              Mathf.Abs(transformPlayer.position.z - transformEnemy.position.z) <= .01f))
        {
            move = true;
        }
        else
        {
            move = false;
        }*/
        if (move && enemyCollision.IsCanGo(Vector3.forward) && moveTimer <= 0 && transformEnemy.position == moveTarget)
        {
            print("is can go : " + enemyCollision.IsCanGo(transformEnemy.forward));
            print("forward : " + transformEnemy.forward);
            moveTarget += transformEnemy.forward * PL_Player_Movement.groundSize;
            //moveTarget += transformEnemy.right * PL_Player_Movement.groundSize * transformEnemy.right.x;
            moveTarget.x = Mathf.RoundToInt(moveTarget.x);
            moveTarget.z = Mathf.RoundToInt(moveTarget.z);
            moveTimer = cooldownMoveTime;
        }

        if (transformEnemy.position == moveTarget)
        {
            transformEnemy.position.Set((int)transformEnemy.position.x, (int)transformEnemy.position.y, (int)transformEnemy.position.z);
        }
        transformEnemy.position = Vector3.Lerp(transformEnemy.position, moveTarget, PL_Player_Movement.lerpTime * Time.deltaTime);
    }

    public void RotateEnemy()
    {
        if (rotate && Mathf.Abs(transformPlayer.position.x - transformEnemy.position.x) <= .01f || Mathf.Abs(transformPlayer.position.z - transformEnemy.position.z) <= .01f)
        {
            lookOnLook = Quaternion.LookRotation(transformPlayer.position - transformEnemy.position);
        }

        transformEnemy.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, PL_Player_Movement.lerpTime * Time.deltaTime);
    }
}
