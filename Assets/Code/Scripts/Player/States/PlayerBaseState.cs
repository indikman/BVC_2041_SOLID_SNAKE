using Code.Scripts.Inputs;
using Code.Scripts.StateMachine;
using UnityEngine;

namespace Code.Scripts.Player.States
{
    public abstract class PlayerBaseState: IState, IPlayerControlListener
    {
        protected PlayerStateMachine _stateMachine;

        public PlayerBaseState(PlayerStateMachine _stateMachine)
        {
            
        }

        public virtual void Enter()
        {
            _stateMachine.ControlChannelSo.Movement += Movement;
            _stateMachine.ControlChannelSo.Crouch += Crouch;
            _stateMachine.ControlChannelSo.Interact += Interact;
            _stateMachine.ControlChannelSo.Interact2 += Interact2;
            _stateMachine.ControlChannelSo.UnequipItem += UnequipItem;
            _stateMachine.ControlChannelSo.UnequipWeapon += UnequipWeapon;
        }
        public virtual void Exit()
        {
            _stateMachine.ControlChannelSo.Movement -= Movement;
            _stateMachine.ControlChannelSo.Crouch -= Crouch;
            _stateMachine.ControlChannelSo.Interact -= Interact;
            _stateMachine.ControlChannelSo.Interact2 -= Interact2;
            _stateMachine.ControlChannelSo.UnequipItem -= UnequipItem;
            _stateMachine.ControlChannelSo.UnequipWeapon -= UnequipWeapon;
        }
        public virtual void Update()
        {
            throw new System.NotImplementedException();
        }



        public virtual void Movement(Vector2 move)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Crouch()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Interact()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Interact2()
        {
            throw new System.NotImplementedException();
        }

        public virtual void UnequipItem()
        {
            throw new System.NotImplementedException();
        }

        public virtual void UnequipWeapon()
        {
            throw new System.NotImplementedException();
        }
    }
}