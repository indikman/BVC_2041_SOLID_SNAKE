using System;
using Code.Scripts.Inputs;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Code.Scripts.SOs.Inputs
{
    [CreateAssetMenu(fileName = "PlayerControlSO", menuName = "SOs/Inputs/PlayerControl", order = 0)]
    public class PlayerControlSO : ScriptableObject, GameInput.IPlayerControlActions
    {
        public UnityEvent<Vector2> HandleMovement;
        public UnityEvent HandleCrouch, HandleInteract, HandleInteract2, UnequipItem, UnequipWeapon;

        private GameInput _input;
        
        private void OnEnable()
        {
            if(_input == null) _input = new GameInput();
            
            _input.PlayerControl.SetCallbacks(this);
            Enable();
        }

        public void Enable()
        {
            if(_input != null)
                _input.PlayerControl.Enable();
        }

        public void Disable()
        {
            if (_input != null)
            {
                _input.PlayerControl.Disable();
            }
        }
        
        public void OnMovement(InputAction.CallbackContext context) => HandleMovement?.Invoke(context.ReadValue<Vector2>());

        public void OnCrouch(InputAction.CallbackContext context) => HandleCrouch?.Invoke();
        public void OnInteract(InputAction.CallbackContext context) => HandleInteract?.Invoke();
        public void OnInteract2(InputAction.CallbackContext context) => HandleInteract2?.Invoke();
        public void OnUnequipItem(InputAction.CallbackContext context) => UnequipWeapon?.Invoke();
        public void OnUnequipWeapon(InputAction.CallbackContext context) => UnequipItem?.Invoke();

    }
}