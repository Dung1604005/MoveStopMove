
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : Character
{
    private Vector2 moveDir;

    private InputSystem_Actions inputActions;

    public void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += EndInputMove;
    }

    public void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= EndInputMove;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
        moveDir = moveDir.normalized;
    }

    public void EndInputMove(InputAction.CallbackContext context)
    {
        moveDir = Vector2.zero;
    }


    public override void Move()
    {
        base.Move();

        if(moveDir.sqrMagnitude > 0.1f)
        {
            ChangeAnim(GameConfig.ANIM_MOVING);
        }
        else
        {
            ChangeAnim(GameConfig.ANIM_IDLE);
        }

        Vector3 moveDir3 = new Vector3(moveDir.x, 0f, moveDir.y);

        ChangeRotation(new Vector3(moveDir.x, 0f, moveDir.y));

        tf.position = Vector3.MoveTowards(tf.position , tf.position + moveDir3, stat.GetSpeed()*Time.fixedDeltaTime);
    }

    public override void StopMove()
    {
        base.StopMove();
        moveDir = Vector2.zero;
    }

    public override bool IsStop()
    {
        return moveDir.sqrMagnitude < 0.1f;
    }

    void FixedUpdate()
    {
        Move();

    }




}
