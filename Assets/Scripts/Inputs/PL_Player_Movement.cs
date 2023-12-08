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
    private Quaternion rotateTarget;
    [SerializeField] private float cooldownMoveTime;
    [SerializeField] private float cooldownRotateTime;
    [SerializeField] private float groundSize;
    [SerializeField] private float lerpTime;
    private void Awake()
    {
        tranformPlayer = transform;
        moveTimer = 0;
        rotateTimer = 0;
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
        tranformPlayer.position = Vector3.Lerp(tranformPlayer.position, moveTarget, lerpTime);
    }
    public void MovePlayerInput(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && moveTimer <= 0)
        {
            moveTarget = tranformPlayer.position + Quaternion.Euler(0, tranformPlayer.eulerAngles.y, 0) * ctx.ReadValue<Vector3>() * groundSize;
            moveTimer = cooldownMoveTime;
        }
    }

    public void RotatePLayer()
    {
        tranformPlayer.rotation = Quaternion.Lerp(tranformPlayer.rotation, rotateTarget, lerpTime);
    }

    public void RotatePlayerInput(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && rotateTimer <= 0)
        {
            rotateTarget = tranformPlayer.rotation * Quaternion.Euler(ctx.ReadValue<Vector3>() * 90);
            rotateTimer = cooldownRotateTime;
        }
    }
}
