using Code.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Code.Scripts.SOs.Inputs;

public class InputDisable : InputManager
{
    public UnityEvent ToggleInput;
    private InputManager inputMngr;
    private GameInputType inputType;

    private void Start()
    {
        inputMngr = GetComponent<InputManager>();
    }
    private void Update()
    {
        ToggleInput?.Invoke();
    }
    public void EnableInput()
    {
        EnableInputType(inputType);
    }

    public void DisableInput()
    {
        DisableInputType(inputType);
    }

}
