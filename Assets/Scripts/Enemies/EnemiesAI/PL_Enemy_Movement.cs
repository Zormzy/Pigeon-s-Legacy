using UnityEngine;

public class PL_Enemy_Movement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PL_Enemy_PlayerDetecter playerDetecter;
    
    private PL_Enemy_Collision enemyCollision;
    //private PL_Enemy_Collision playerCollision;
    private PL_Enemy_Attack enemyAttack;
    private Transform transformEnemy;
    private PL_Player_Movement playerMovement;
    private Transform transformPlayer;
    private GameObject player;

    [Header("Variables")]
    private float rotateTimer;
    private Vector3 moveTarget;
    private Quaternion rotationTarget;
    private float rotation;
    private bool move = true;
    private bool rotate = false;
    private Quaternion lookOnLook;
    private bool mooving = false;
    private float lerpTime = 0;
    private float lerpTimeRotation = 0;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        transformEnemy = transform;
        rotateTimer = 0;/*
        rotation = 0;*/
        lookOnLook = transformEnemy.rotation;
        rotationTarget = transformEnemy.rotation;
        moveTarget = transformEnemy.position;
        rotate = true;
        enemyCollision = GetComponent<PL_Enemy_Collision>();
        //playerCollision = GetComponent<PL_Enemy_Collision>();
        enemyAttack = GetComponent<PL_Enemy_Attack>();
        playerMovement = player.GetComponent<PL_Player_Movement>();
        transformPlayer = player.transform;
    }

    private void Update()
    {
        Timer();
        MoveEnemy();
        RotateEnemy();
    }

    private void Timer()
    {

        if (rotateTimer >= 0)
            rotateTimer -= Time.deltaTime;
    }

    private void MoveEnemy()
    {
        if ((Mathf.Abs(transformPlayer.position.x - transformEnemy.position.x) <= .01f ||
             Mathf.Abs(transformPlayer.position.z - transformEnemy.position.z) <= .01f) && playerDetecter.IsPlayerDetected())
        {
            RotateTowardsEnemy(Quaternion.LookRotation(transformPlayer.position - transformEnemy.position));
        }
        if (enemyCollision.IsCanGo("forward") && transformEnemy.position == moveTarget && (!playerMovement.IsInPlayerArea() || playerMovement.IsInPlayerArea() && !playerMovement.IsMoving()))
        {
            print("enemy moving");
            lerpTime = 0;
            moveTarget += transformEnemy.forward * PL_Player_Movement.groundSize;
            moveTarget.x = Mathf.RoundToInt(moveTarget.x);
            moveTarget.z = Mathf.RoundToInt(moveTarget.z);
            mooving = true;
        }
        if(!enemyCollision.IsCanGo("forward") && enemyCollision.ObjectInFront() != "Player" && enemyCollision.ObjectInFront() != null)
        {
            RotateTowardsEnemy(Quaternion.AngleAxis(transformEnemy.eulerAngles.y + 90, Vector3.up));
        }

        if (transformEnemy.position == moveTarget)
        {
            mooving = false;
        }
        if (lerpTime < moveSpeed)
        {
            lerpTime += Time.deltaTime;

            float t = lerpTime / moveSpeed;
            transformEnemy.position = Vector3.Lerp(transformEnemy.position, moveTarget, t);
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
        //if (lerpTimeRotation < rotateSpeed)
        //{
        //    lerpTimeRotation += Time.deltaTime;

        //    float t = lerpTimeRotation / rotateSpeed;
        //}
        //else
        //{

        //    lerpTimeRotation = 0;
        //}

        transformEnemy.rotation = lookOnLook;
    }

    public bool IsMoving()
    {
        return mooving;
    }
}
    