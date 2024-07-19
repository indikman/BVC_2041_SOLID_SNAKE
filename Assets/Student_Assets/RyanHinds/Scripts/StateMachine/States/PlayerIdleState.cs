using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Idling");
        SetMovementAnimation();
    }

    public override void Update()
    {
        if (Mathf.Abs(_stateMachine.MovementVector.x) > Mathf.Epsilon || Mathf.Abs(_stateMachine.MovementVector.y) > Mathf.Epsilon)
        {
            _stateMachine.ChangeState(_stateMachine.MoveState);
        }
    }
}
