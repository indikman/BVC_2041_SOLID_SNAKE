using Code.Scripts.SOs.Inputs;
using UnityEngine;

namespace Code.Scripts.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        [SerializeField] private PlayerControlSO playerControl;
        protected override void Initialize() 
        {
            
        }
    }
}