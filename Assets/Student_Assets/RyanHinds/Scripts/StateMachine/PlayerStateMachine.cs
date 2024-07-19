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
    [field: SerializeField] public Animator AnimationController;
    #endregion

    #region ScriptableObjects
    [field: SerializeField] public PlayerInteractionsSO PlayerInteractions { get; private set; }
    [field: SerializeField] public PlayerDataSO PlayerData;
    [field: SerializeField] public PlayerControlChannelSO PlayerControls { get; private set; }
    #endregion

    #region Serialized Variables
    [SerializeField] private Transform footPos;
    [field: SerializeField] public Vector2 MovementVector;
    #endregion

    public IState CurrentState;

    #region States
    public PlayerIdleState IdleState;
    public PlayerMoveState MoveState;
    #endregion

    public event Action<IState> StateChanged;

    public PlayerStateMachine()
    {
        this.IdleState = new PlayerIdleState(this);
        this.MoveState = new PlayerMoveState(this);
    }

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        AnimationController = GetComponent<Animator>();
    }

    private void Start()
    {
        Initialize(IdleState);
    }

    private void FixedUpdate()
    {
        CurrentState.PhysicsUpdate();
    }

    private void Update()
    {
        CurrentState.Update();
    }

    void Initialize(IState state)
    {
        CurrentState = state;
        state.Enter();
        
        StateChanged?.Invoke(state);
    }

    public void ChangeState(IState nextState)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();
        }
        
        StateChanged?.Invoke(nextState);
    }
}
