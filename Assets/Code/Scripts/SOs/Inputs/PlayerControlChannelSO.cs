using System;
using Code.Scripts.Inputs;
using UnityEngine;
using UnityEngine.Events;
// using UnityEditor.Timeline.Actions;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Code.Scripts.SOs.Inputs
{
    [CreateAssetMenu(fileName = "PlayerControlChannelSO", menuName = "SOs/Inputs/PlayerControlChannel", order = 0)]
    public class PlayerControlChannelSO : ScriptableObject
    {
        public event Action<Vector2> Movement;
        public event Action Interact,Crouch, Interact2, UnequipItem, UnequipWeapon;
        
        public void HandleMovement(Vector2 movement) => Movement?.Invoke(movement);
        public void HandleCrouch() => Crouch?.Invoke();
        public void HandleInteract() => Interact?.Invoke();
        public void HandleInteract2() => Interact2?.Invoke();

        public void HandleUnequipItem() => UnequipItem?.Invoke();

        public void HandleUnequipWeapon() => UnequipWeapon?.Invoke();
    }
}