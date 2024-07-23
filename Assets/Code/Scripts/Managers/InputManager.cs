using System;
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
        [SerializeField] private MenuInteractionSO menuInputChannel;
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
                _gameInput.PlayerControl.Movement.performed += (val) => playerControlChannel.HandleMovement(val.ReadValue<Vector2>());
                _gameInput.PlayerControl.Crouch.performed += (val) => playerControlChannel.HandleCrouch();
                _gameInput.PlayerControl.Interact.performed += (val) => playerControlChannel.HandleInteract();
                _gameInput.PlayerControl.Interact2.performed += (val) => playerControlChannel.HandleInteract2();
                _gameInput.PlayerControl.UnequipItem.performed += (val) => playerControlChannel.HandleUnequipItem();
                _gameInput.PlayerControl.UnequipWeapon.performed += (val) => playerControlChannel.HandleUnequipWeapon();
                _actionMaps.Add(GameInputType.PlayerControl, _gameInput.PlayerControl);
                //codec control
                _gameInput.CodecCall.Open.performed += (val) => codecControlChannel?.HandleOpen();
                _gameInput.CodecCall.Next.performed += (val) => codecControlChannel?.HandleNext();
                _actionMaps.Add(GameInputType.CodecCall, _gameInput.CodecCall);
                // Menu Mapping
                _gameInput.MenuControl.Open.performed += (ctx) => menuInputChannel?.HandleMenuOpen();
                _gameInput.MenuControl.Close.performed += (ctx) => menuInputChannel?.HandleMenuClose();
                _gameInput.MenuControl.ScrollMenu.performed += (ctx) => menuInputChannel?.HandleMenuScroll(ctx.ReadValue<float>());
                _gameInput.MenuControl.SelectItem.performed += (ctx) => menuInputChannel?.HandleItemSelected();
                _actionMaps.Add(GameInputType.MenuControl, _gameInput.MenuControl);
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
    }
    
    public enum GameInputType { PlayerControl, MenuControl, CodecCall}
    
}