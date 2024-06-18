using System.Collections.Generic;
using Code.Scripts.SOs.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Scripts.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        [SerializeField] private PlayerControlChannelSO playerControlChannel;
        [SerializeField] private CodecControlChannelSO codecControlChannel;
        private GameInput _gameInput;
        private GameInputType _gameInputType;
        private Dictionary<GameInputType, InputActionMap> _actionMaps;
        protected override void Initialize()
        {
            if (_actionMaps == null)
                _actionMaps = new Dictionary<GameInputType, InputActionMap>();
            if (_gameInput == null)
            {
                _gameInput = new GameInput();
                //player control 
                _gameInput.PlayerControl.Movement.performed +=
                    (val) => playerControlChannel.HandleMovement(val.ReadValue<Vector2>());
                _gameInput.PlayerControl.Crouch.performed += (val) => playerControlChannel?.HandleCrouch();
                _gameInput.PlayerControl.Interact.performed += (val) => playerControlChannel?.HandleInteract();
                _gameInput.PlayerControl.Interact2.performed += (val) => playerControlChannel?.HandleInteract2();
                _gameInput.PlayerControl.UnequipItem.performed += (val) => playerControlChannel?.HandleUnequipItem();
                _gameInput.PlayerControl.UnequipWeapon.performed += (val) => playerControlChannel?.HandleUnequipWeapon();
                _actionMaps.Add(GameInputType.PlayerControl, _gameInput.PlayerControl);
                //codec control
                _gameInput.CodecCall.Open.performed += (val) => codecControlChannel?.HandleOpen();
                _gameInput.CodecCall.Next.performed += (val) => codecControlChannel?.HandleNext();
                _actionMaps.Add(GameInputType.CodecCall, _gameInput.CodecCall);
            }
            _gameInput.Enable();
        }

        public void EnableInputType(GameInputType inputType)
        {
            _actionMaps[inputType].Enable();
        }

        public void DisableInputType(GameInputType inputType)
        {
            _actionMaps[inputType].Disable();
        }
        
        public void EnablePlayerInput()
        {
            _gameInput.PlayerControl.Movement.Enable();
            _gameInput.PlayerControl.Crouch.Enable();
            _gameInput.PlayerControl.UnequipItem.Enable();
            _gameInput.PlayerControl.UnequipWeapon.Enable();
        }

        public void DisablePlayerInput()
        {
            _gameInput.PlayerControl.Movement.Disable();
            _gameInput.PlayerControl.Crouch.Disable();
            _gameInput.PlayerControl.UnequipItem.Disable();
            _gameInput.PlayerControl.UnequipWeapon.Disable();
        }
    }
    
    public enum GameInputType { PlayerControl, MenuControl, CodecCall}
    
}