using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "CodecControlSO", menuName = "SOs/Inputs/CodecControlSO", order = 1)]
public class CodecControlChannelSO : ScriptableObject
{
    public UnityEvent Open, Next;
    
    public void HandleOpen() => Open?.Invoke();
    public void HandleNext() => Next?.Invoke();
}
