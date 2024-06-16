using UnityEngine;

namespace Code.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private InputManager inputManager;
        
        public void PauseGame()
        {
            inputManager.DisableInputType(GameInputType.PlayerControl);
        }
        
        public void ResumeGame()
        {
            inputManager.EnableInputType(GameInputType.PlayerControl);
        }
        
        public void EnterCodecView()
        {
            inputManager.DisableInputType(GameInputType.PlayerControl);
        }
        
        public void ExitCodecView()
        {
            inputManager.EnableInputType(GameInputType.PlayerControl);
        }
    }
}