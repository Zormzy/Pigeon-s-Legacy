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

    private void Update()
    {
        if (moveTimer > 0)
            moveTimer -= Time.deltaTime;
        if (rotateTimer > 0)
            rotateTimer -= Time.deltaTime;
        MoveEnemy();

        transformEnemy.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, PL_Player_Movement.lerpTime * Time.deltaTime);
    }

    private void MoveEnemy()
    {
        print("can go forward : " + enemyCollision.IsCanGo("forward"));
        print("can go left : " + enemyCollision.IsCanGo("left"));
        print("can go right : " + enemyCollision.IsCanGo("right"));
        print("can go back : " + enemyCollision.IsCanGo("back"));
        if (!enemyCollision.IsCanGo("forward"))
        {
            print("tourne");
            RotateEnemy(false, 90);
        }

        if (enemyCollision.IsCanGo("forward") && moveTimer <= 0 && transformEnemy.position == moveTarget)
        {
            moveTarget += transformEnemy.forward * PL_Player_Movement.groundSize;
            moveTarget.x = Mathf.RoundToInt(moveTarget.x);
            moveTarget.z = Mathf.RoundToInt(moveTarget.z);
            moveTimer = cooldownMoveTime;
        }

        //if (transformEnemy.position == moveTarget)
        //{
        //    transformEnemy.position.Set((int)transformEnemy.position.x, (int)transformEnemy.position.y, (int)transformEnemy.position.z);
        //}
        transformEnemy.position = Vector3.Lerp(transformEnemy.position, moveTarget, PL_Player_Movement.lerpTime * Time.deltaTime);

        if((Mathf.Abs(transformPlayer.position.x - transformEnemy.position.x) <= .01f ||
            Mathf.Abs(transformPlayer.position.z - transformEnemy.position.z) <= .01f) && playerDetecter.IsPlayerDetected())
        {
            RotateEnemy(true, 0);
        }
    }

    public void RotateEnemy(bool player, float angle)
    {
       if(transformEnemy.rotation == lookOnLook) lookOnLook = (player) ? Quaternion.LookRotation(transformPlayer.position - transformEnemy.position) : Quaternion.AngleAxis(transformEnemy.eulerAngles.y + angle, Vector3.up);
    }
}
    