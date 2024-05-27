using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Serialize Fields

    [Header("Movement")] [SerializeField]private float speed =5f, acceleration = .1f;

    [SerializeField] private Transform _footLocation;
    

    #endregion
    private Vector3 _movementDirection;
    private Rigidbody _rb;
    private CharacterController _characterController;

    private PlayerAnimationController _animationController;
    // Start is called before the first frame update
    void Awake()
    {
       _characterController = GetComponent<CharacterController>();
       _animationController = GetComponent<PlayerAnimationController>();
    }

    public void HandleMovement(Vector2 movement)
    {
        _movementDirection = new Vector3(movement.x, 0, movement.y);
        _movementDirection.Normalize();
        _animationController.SetMovement(_movementDirection);
    }

    public void AnswerCall()
    {
        CodecEvent[] codecEvents = FindObjectsOfType<CodecEvent>();
        foreach(var codecEvent in codecEvents)
        {
            codecEvent.OpenCall();
        }
    }


    private bool wasGrounded = false;
    private void FixedUpdate()
    {
        var newMoveDirection = Camera.main.transform.rotation * _movementDirection;
        newMoveDirection.y = 0.0f;
        newMoveDirection.Normalize();
        _characterController.Move(newMoveDirection * speed * Time.fixedDeltaTime);
        if (!_characterController.isGrounded)
        {
            Vector3 down = -transform.up;
            RaycastHit hit;
            if(Physics.Raycast(_footLocation.position, down, out hit, 100f, LayerMask.GetMask("Ground")))
            {
                _characterController.Move(Vector3.down * (transform.position.y - hit.point.y));
            }

        }
        if(_movementDirection != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newMoveDirection),
            acceleration * Time.fixedDeltaTime);

    }
}
