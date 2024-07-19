using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Moving");
        SetMovementAnimation();
        _stateMachine.AnimationController.CrossFadeInFixedTime("Running", 0.1f);
    }

    public override void Update()
    {
        if (_stateMachine.MovementVector == Vector2.zero)
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        Vector3 inputDir = new Vector3(_stateMachine.MovementVector.x, 0f, _stateMachine.MovementVector.y);
        var moveDir = Camera.main.transform.rotation * inputDir;
        moveDir.y = 0f;
        moveDir.Normalize();
        _stateMachine.Controller.Move( moveDir * _stateMachine.PlayerData.Speed * Time.fixedDeltaTime);
        SetLookDir(moveDir);
    }
}
