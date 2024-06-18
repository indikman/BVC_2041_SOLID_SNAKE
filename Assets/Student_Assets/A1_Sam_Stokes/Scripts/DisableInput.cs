using UnityEngine;
using UnityEngine.Events;
using Code.Scripts.Managers;
using Code.Scripts.SOs.Inputs;

public class InputDisable : MonoBehaviour
{
    public UnityEvent ToggleInput;

    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameInputType inputType;

    private void Update()
    {
        ToggleInput?.Invoke();
    }

    public void EnableInput()
    {
        inputManager.EnableInputType(inputType);
    }

    public void DisableInput()
    {
        inputManager.DisableInputType(inputType);
    }
}
