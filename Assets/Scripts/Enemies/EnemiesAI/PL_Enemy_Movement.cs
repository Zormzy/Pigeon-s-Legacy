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
    private PL_Enemy_Collision playerCollision;
    [SerializeField] private float cooldownMoveTime;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private PL_Enemy_PlayerDetecter playerDetecter;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {

        transformEnemy = transform;
        moveTimer = 0;
        rotateTimer = 0;
        rotation = 0;
        rotationTarget = transformEnemy.rotation;
        moveTarget = transformEnemy.position;
        rotate = true;
        enemyCollision = GetComponent<PL_Enemy_Collision>();
        playerCollision = GetComponent<PL_Enemy_Collision>();
    }

    private void LateUpdate()
    {
        Timer();
        MoveEnemy();
        RotateEnemy();
    }

    private void Timer()
    {
        if (moveTimer >= 0)
            moveTimer -= Time.deltaTime;
        if (rotateTimer >= 0)
            rotateTimer -= Time.deltaTime;
    }

    private void MoveEnemy()
    {
        if (!enemyCollision.IsCanGo("forward") && playerCollision.ObjectInFront() != "Player")
        {
            RotateTowardsEnemy(Quaternion.AngleAxis(transformEnemy.eulerAngles.y + 90, Vector3.up));
        }

        if (enemyCollision.IsCanGo("forward") && moveTimer <= 0 && transformEnemy.position == moveTarget)
        {
            moveTarget += transformEnemy.forward * PL_Player_Movement.groundSize;
            moveTarget.x = Mathf.RoundToInt(moveTarget.x);
            moveTarget.z = Mathf.RoundToInt(moveTarget.z);
            moveTimer = cooldownMoveTime;
        }

        transformEnemy.position = Vector3.Lerp(transformEnemy.position, moveTarget, PL_Player_Movement.lerpTime * Time.deltaTime);

        if ((Mathf.Abs(transformPlayer.position.x - transformEnemy.position.x) <= .01f ||
             Mathf.Abs(transformPlayer.position.z - transformEnemy.position.z) <= .01f) && playerDetecter.IsPlayerDetected())
        {
            RotateTowardsEnemy(Quaternion.LookRotation(transformPlayer.position - transformEnemy.position));
        }

    }

    private void RotateTowardsEnemy(Quaternion target)
    {
        if (rotateTimer <= 0)
        {
            lookOnLook = target;
            rotateTimer = .5f;
        }
    }

    private void RotateEnemy()
    {
        transformEnemy.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, PL_Player_Movement.lerpTime * Time.deltaTime);
    }
}
    