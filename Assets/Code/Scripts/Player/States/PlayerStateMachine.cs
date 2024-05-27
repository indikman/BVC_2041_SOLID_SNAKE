using Code.Scripts.Inputs;
using Code.Scripts.SOs.Inputs;
using Code.Scripts.SOs.Player;
using Code.Scripts.StateMachine;
using UnityEngine;

namespace Code.Scripts.Player.States
{   
    public class PlayerStateMachine : BaseStateMachine, IPlayerControlListener
    {
        #region Serialize Fields
    
        [SerializeField] protected PlayerDataSO playerData;
        [field: SerializeField] public PlayerInteractionsSO PlayerInteractions { get; private set; }
        [SerializeField] protected Transform _footLocation;
        [field: SerializeField] public PlayerControlChannelSO ControlChannelSo { get; private set; }
        #endregion
        protected Rigidbody _rb;
        protected CharacterController _characterController;

        protected PlayerAnimationController _animationController;
        public void Movement(Vector2 move)
        {
            throw new System.NotImplementedException();
        }

        public void Crouch()
        {
            throw new System.NotImplementedException();
        }

        public void Interact()
        {
            throw new System.NotImplementedException();
        }

        public void Interact2()
        {
            throw new System.NotImplementedException();
        }

        public void UnequipItem()
        {
            throw new System.NotImplementedException();
        }

        public void UnequipWeapon()
        {
            throw new System.NotImplementedException();
        }
    }
}