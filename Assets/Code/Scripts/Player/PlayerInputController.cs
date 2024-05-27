using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerController _playerController;
    private GameInput _gameInput;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        _gameInput = new GameInput();
        _gameInput.PlayerControl.Movement.performed += (val) => _playerController.HandleMovement(val.ReadValue<Vector2>());
        _gameInput.PlayerControl.CodecAnswer.performed += (val) => _playerController.AnswerCall();
        _gameInput.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
