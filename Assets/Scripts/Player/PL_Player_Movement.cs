using UnityEngine;
using UnityEngine.InputSystem;

public class PL_Player_Movement : MonoBehaviour
{
    private Transform transformPlayer;
    private float rotateTimer;
    private Vector3 moveTarget;
    private Quaternion rotationTarget;
    private float rotation;
    private bool pressed = true;
    private bool move = false;
    private Vector3 contextValue;
    private bool rotate = false;
    private Vector3 contextRotationValue;
    public static float groundSize = 1;
    private PL_Player_Collision playerCollision;
    private PL_Enemy_Movement enemyMovement;
    private bool mooving = false;
    private RaycastHit[] raycastHitsDetectEnemy = new RaycastHit[8];
    private bool[] raycastHitsDetectEnemyBool = new bool[8];
    private float lerpTime = 0;
    private float lerpTimeRotation = 0;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private void Awake()
    {
        transformPlayer = transform;
        rotateTimer = 0;
        rotation = transformPlayer.eulerAngles.y;
        rotationTarget = transformPlayer.rotation;
        moveTarget = transformPlayer.position;
        playerCollision = GetComponent<PL_Player_Collision>();
    }

    private void Update()
    {

        if (rotateTimer > 0)
            rotateTimer -= Time.deltaTime;

        MovePLayer();
        RotatePLayer();
        IsInPlayerArea();
    }

    private void MovePLayer()
    {
        if (rotationTarget == transformPlayer.rotation && move && playerCollision.IsCanGo(contextValue) && transformPlayer.position == moveTarget && (enemyMovement == null || enemyMovement != null && (!IsInPlayerArea() || IsInPlayerArea() && !enemyMovement.IsMoving())))
        {
            lerpTime = 0;
            moveTarget += transformPlayer.forward * groundSize * contextValue.z;
            moveTarget += transformPlayer.right * groundSize * contextValue.x;
            moveTarget.x = Mathf.RoundToInt(moveTarget.x);
            moveTarget.z = Mathf.RoundToInt(moveTarget.z);
            mooving = true;
        }

        if (transformPlayer.position == moveTarget)
        {
            mooving = false;
        }

        if (transformPlayer.position == moveTarget)
        {
            transformPlayer.position.Set((int)transformPlayer.position.x, (int)transformPlayer.position.y, (int)transformPlayer.position.z);
        }
        if(lerpTime < moveSpeed)
        {
            lerpTime += Time.deltaTime;

            float t = lerpTime / moveSpeed;
            transformPlayer.position = Vector3.Lerp(transformPlayer.position, moveTarget, t);
        }
    }

    public bool IsInPlayerArea()
    {
        bool retour = false;
        //Debug.DrawRay(transformPlayer.position, (transformPlayer.forward) * 2, Color.green);
        //Debug.DrawRay(transformPlayer.position, (transformPlayer.forward + transformPlayer.right), Color.red);
        raycastHitsDetectEnemyBool[0] = Physics.Raycast(transformPlayer.position, (transformPlayer.forward) * 2, out raycastHitsDetectEnemy[0], 2);
        raycastHitsDetectEnemyBool[1] = Physics.Raycast(transformPlayer.position, (transformPlayer.forward + transformPlayer.right), out raycastHitsDetectEnemy[1], 1);
        raycastHitsDetectEnemyBool[2] = Physics.Raycast(transformPlayer.position, (transformPlayer.right) * 2, out raycastHitsDetectEnemy[2], 2);
        raycastHitsDetectEnemyBool[3] = Physics.Raycast(transformPlayer.position, (-transformPlayer.forward + transformPlayer.right), out raycastHitsDetectEnemy[3], 1);
        raycastHitsDetectEnemyBool[4] = Physics.Raycast(transformPlayer.position, (-transformPlayer.forward) * 2, out raycastHitsDetectEnemy[4], 2);
        raycastHitsDetectEnemyBool[5] = Physics.Raycast(transformPlayer.position, (-transformPlayer.forward + -transformPlayer.right), out raycastHitsDetectEnemy[5], 1);
        raycastHitsDetectEnemyBool[6] = Physics.Raycast(transformPlayer.position, (-transformPlayer.right) * 2, out raycastHitsDetectEnemy[6], 2);
        raycastHitsDetectEnemyBool[7] = Physics.Raycast(transformPlayer.position, (transformPlayer.forward + -transformPlayer.right), out raycastHitsDetectEnemy[7], 1);
        for(int i = 0;i<8; i++)
        {
           if(raycastHitsDetectEnemyBool[i])
           {
               retour = (raycastHitsDetectEnemy[i].transform.tag == "Enemy") ? true : false;

               enemyMovement = raycastHitsDetectEnemy[i].transform.gameObject.GetComponent<PL_Enemy_Movement>();
           }
           if (retour) break;
        }
        return retour;
    }

    public void MovePlayerInput(InputAction.CallbackContext ctx)
    {
        contextValue = ctx.ReadValue<Vector3>();
        move = true;
        if (ctx.canceled)
        {
            move = false;
        }
    }

    private void RotatePLayer()
    {
        if(rotate && rotationTarget == transformPlayer.rotation)
        {
            lerpTimeRotation = 0;
            rotationTarget = Quaternion.Euler(0, rotation + 90 * contextRotationValue.y, 0);
            rotation += 90 * contextRotationValue.y;
        }

        if (lerpTimeRotation < rotateSpeed)
        {
            lerpTimeRotation += Time.deltaTime;

            float t = lerpTimeRotation / rotateSpeed;
            transformPlayer.rotation = Quaternion.Lerp(transformPlayer.rotation, rotationTarget, t);
        }
    }

    public void RotatePlayerInput(InputAction.CallbackContext ctx)
    {
        contextRotationValue = ctx.ReadValue<Vector3>();
        if (ctx.performed && rotateTimer <= 0 && pressed)
        {
            rotate = true;
        }

        if (ctx.canceled)
        {
            rotate = false;
        }
    }

    public bool IsMoving()
    {
        return mooving;
    }
}
