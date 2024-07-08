using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Code.Scripts.SOs.Inputs;
using Code.Scripts.SOs.Player;

public class PlayerStateMachine : MonoBehaviour
{
    #region Components
    [field: SerializeField] public CharacterController Controller;
    [field: SerializeField] public PlayerAnimationController AnimationController;
    #endregion

    #region ScriptableObjects
    [field: SerializeField] public PlayerInteractionsSO PlayerInteractions { get; private set; }
    [field: SerializeField] public PlayerDataSO PlayerData;
    [field: SerializeField] public PlayerControlChannelSO PlayerControls { get; private set; }
    #endregion

    #region Serialized Variables
    [SerializeField] private Transform footPos;
    #endregion

    public IState CurrentState;

    #region States
    #endregion

    public event Action<IState> StateChanged;

    public PlayerStateMachine()
    {
    }

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        
    }
}
