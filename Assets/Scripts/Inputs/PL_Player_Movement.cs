using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PL_Player_Movement : MonoBehaviour
{
    private Transform tranformPlayer;
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
    [SerializeField] private float groundSize;
    [SerializeField] private float lerpTime;
    [SerializeField] private PL_Player_Collision playerCollision;

    private void Awake()
    {
        tranformPlayer = transform;
        moveTimer = 0;
        rotateTimer = 0;
        rotation = 0;
        rotationTarget = tranformPlayer.rotation;
        moveTarget = tranformPlayer.position;
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
        if(move && playerCollision.IsCanGo(contextValue) && moveTimer <= 0 && tranformPlayer.position == moveTarget)
        {
            moveTarget += tranformPlayer.forward * groundSize * contextValue.z;
            moveTarget += tranformPlayer.right * groundSize * contextValue.x;
            moveTarget.x = Mathf.RoundToInt(moveTarget.x);
            moveTarget.z = Mathf.RoundToInt(moveTarget.z);
            moveTimer = cooldownMoveTime;
        }

        if (tranformPlayer.position == moveTarget)
        {
            tranformPlayer.position.Set((int)tranformPlayer.position.x, (int)tranformPlayer.position.y, (int)tranformPlayer.position.z);
            print(moveTarget);
        }
        tranformPlayer.position = Vector3.Lerp(tranformPlayer.position, moveTarget, lerpTime * Time.deltaTime);
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

    public void RotatePLayer()
    {
        if(rotate && rotationTarget == tranformPlayer.rotation)
        {
            rotationTarget = Quaternion.Euler(0, rotation + 90 * contextRotationValue.y, 0);
            rotation += 90 * contextRotationValue.y;
        }
        tranformPlayer.rotation = Quaternion.Lerp(tranformPlayer.rotation, rotationTarget, lerpTime * Time.deltaTime);
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
