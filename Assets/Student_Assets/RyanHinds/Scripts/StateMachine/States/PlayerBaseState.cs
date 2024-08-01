using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Inputs;
using UnityEngine;

public class PlayerBaseState : IState, IPlayerControlListener
{
    protected PlayerStateMachine _stateMachine;

    private float _rotationDamping = 7.5f;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    public virtual void Enter()
    {
        RegisterListeners();
    }

    public virtual void Update() {}

    public virtual void PhysicsUpdate() {}

    public virtual void Exit()
    {
        DeregisterListeners();
    }

    protected void RegisterListeners()
    {
        _stateMachine.PlayerControls.Movement += Movement;
        _stateMachine.PlayerControls.Crouch += Crouch;
        _stateMachine.PlayerControls.Interact += Interact;
        _stateMachine.PlayerControls.Interact2 += Interact2;
        _stateMachine.PlayerControls.UnequipItem += UnequipItem;
        _stateMachine.PlayerControls.UnequipWeapon += UnequipWeapon;
    }

    protected void DeregisterListeners()
    {
        _stateMachine.PlayerControls.Movement -= Movement;
        _stateMachine.PlayerControls.Crouch -= Crouch;
        _stateMachine.PlayerControls.Interact -= Interact;
        _stateMachine.PlayerControls.Interact2 -= Interact2;
        _stateMachine.PlayerControls.UnequipItem -= UnequipItem;
        _stateMachine.PlayerControls.UnequipWeapon -= UnequipWeapon;
    }

    public void Movement(Vector2 move)
    {
        _stateMachine.MovementVector = move;
        _stateMachine.MovementVector.Normalize();
    }

    protected void SetLookDir(Vector3 inputDir)
    {
        if (inputDir.magnitude > Mathf.Epsilon)
        {
            _stateMachine.transform.rotation = Quaternion.Lerp(_stateMachine.transform.rotation, Quaternion.LookRotation(inputDir), _rotationDamping * Time.fixedDeltaTime);
        }
    }

    protected void SetMovementAnimation()
    {
        if (_stateMachine.MovementVector == Vector2.zero)
        {
            _stateMachine.AnimationController.CrossFadeInFixedTime("idle", 0.1f);
        }
        else if (_stateMachine.MovementVector != Vector2.zero)
        {
            _stateMachine.AnimationController.CrossFadeInFixedTime("Running", 0.1f);
        }
    }

    public void Crouch() {}

    public void Interact()
    {
        _stateMachine.ChangeState(_stateMachine.InteractState);
    }

    public void Interact2() {}

    public void UnequipItem() {}

    public void UnequipWeapon() {}
}
