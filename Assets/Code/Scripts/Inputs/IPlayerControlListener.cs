using UnityEngine;

namespace Code.Scripts.Inputs
{
    public interface IPlayerControlListener
    {
        void Movement(Vector2 move);
        void Crouch();
        void Interact();
        void Interact2();
        void UnequipItem();
        void UnequipWeapon();
    }
}