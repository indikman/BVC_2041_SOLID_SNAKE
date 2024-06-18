using Code.Scripts.Managers;
using UnityEngine;
using UnityEngine.Events;

public class HandlePlayerControl : Singleton<HandlePlayerControl>
{
    UnityEvent<GameInputType> enablePlayerControl;
    UnityEvent<GameInputType> disablePlayerControl;
    InputManager inputManager;

    protected override void Initialize()
    {
        enablePlayerControl = new UnityEvent<GameInputType>();
        disablePlayerControl = new UnityEvent<GameInputType>();
        inputManager = FindObjectOfType<InputManager>();

        enablePlayerControl.AddListener(inputManager.EnableInputType);
        disablePlayerControl.AddListener(inputManager.DisableInputType);
    }

    public void EnablePlayerControl()
    {
        enablePlayerControl.Invoke(GameInputType.PlayerControl);
    }
    public void DisablePlayerControl()
    {
        disablePlayerControl.Invoke(GameInputType.PlayerControl);
    }
}
