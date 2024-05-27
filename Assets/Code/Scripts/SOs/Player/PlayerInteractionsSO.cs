using UnityEngine;
using UnityEngine.Events;
namespace Code.Scripts.SOs.Player
{
    [CreateAssetMenu(fileName = "PlayerInteractionSO", menuName = "SOs/Player/PlayerInteractionSO", order = 0)]
    public class PlayerInteractionsSO : ScriptableObject
    {
        public UnityEvent<Transform> Footsteps;
        public UnityEvent<Transform> InteractTriggered;
        public void Interact(Transform transform) => InteractTriggered?.Invoke(transform);
        public void Stepping(Transform transform) => Footsteps?.Invoke(transform);
    }
}