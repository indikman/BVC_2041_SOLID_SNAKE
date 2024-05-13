using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "CodecControlSO", menuName = "SOs/Inputs/CodecControlSO", order = 1)]
public class CodecCallSO : ScriptableObject, GameInput.ICodecCallActions
{
    public UnityEvent Open, Next;
    private GameInput _input;
    private void OnEnable()
    {
        if(_input == null) _input = new GameInput();
        Debug.Log("We enabled the SO");
        _input.CodecCall.SetCallbacks(this);
        Enable();
    }

    public void Enable()
    {
        _input.CodecCall.Enable();
    }

    public void Disable()
    {
        _input.CodecCall.Disable();
    }

    public void OnOpen(InputAction.CallbackContext context) => Open?.Invoke();
    public void OnNext(InputAction.CallbackContext context) => Next?.Invoke();
}
