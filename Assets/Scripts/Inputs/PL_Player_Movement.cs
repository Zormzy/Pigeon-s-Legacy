using UnityEngine;
using UnityEngine.InputSystem;

public class PL_Player_Movement : MonoBehaviour
{
    private Transform transformPlayer;
    private float moveTimer;
    private float rotateTimer;
    private Vector3 moveTarget;
    private Quaternion rotationTarget;
    private float rotation;
    private bool pressed = true;
    private bool move = false;
    private Vector3 contextValue;
    private bool rotate = false;
    private Vector3 contextRotationValue;
    [SerializeField] private float cooldownMoveTime;
    public static float groundSize = 1;
    public static float lerpTime = 17;
    [SerializeField] private PL_Player_Collision playerCollision;

    private void Awake()
    {
        transformPlayer = transform;
        moveTimer = 0;
        rotateTimer = 0;
        rotation = transformPlayer.eulerAngles.y;
        print(rotation);
        rotationTarget = transformPlayer.rotation;
        moveTarget = transformPlayer.position;
    }

    private void Update()
    {
        if (moveTimer > 0)
            moveTimer -= Time.deltaTime;
        if (rotateTimer > 0)
            rotateTimer -= Time.deltaTime;
        MovePLayer();
        RotatePLayer();
    }

    private void MovePLayer()
    {
        if(move && playerCollision.IsCanGo(contextValue) && moveTimer <= 0 && transformPlayer.position == moveTarget)
        {
            moveTarget += transformPlayer.forward * groundSize * contextValue.z;
            moveTarget += transformPlayer.right * groundSize * contextValue.x;
            moveTarget.x = Mathf.RoundToInt(moveTarget.x);
            moveTarget.z = Mathf.RoundToInt(moveTarget.z);
            moveTimer = cooldownMoveTime;
        }

        if (transformPlayer.position == moveTarget)
        {
            transformPlayer.position.Set((int)transformPlayer.position.x, (int)transformPlayer.position.y, (int)transformPlayer.position.z);
        }
        transformPlayer.position = Vector3.Lerp(transformPlayer.position, moveTarget, lerpTime * Time.deltaTime);
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
            rotationTarget = Quaternion.Euler(0, rotation + 90 * contextRotationValue.y, 0);
            rotation += 90 * contextRotationValue.y;
        }
        transformPlayer.rotation = Quaternion.Lerp(transformPlayer.rotation, rotationTarget, lerpTime * Time.deltaTime);
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
}
