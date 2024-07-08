using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Inputs;
using UnityEngine;

public class PlayerBaseState : IState, IPlayerControlListener
{
    public virtual void Enter() {}

    public virtual void Update() {}

    public virtual void PhysicsUpdate() {}

    public virtual void Exit() {}
    
    public void Movement(Vector2 move) {}

    public void Crouch() {}

    public void Interact() {}

    public void Interact2() {}

    public void UnequipItem() {}

    public void UnequipWeapon() {}
}
