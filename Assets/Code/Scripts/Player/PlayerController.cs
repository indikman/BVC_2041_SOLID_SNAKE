using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Inputs;
using Code.Scripts.SOs.Inputs;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerControlListener
{
    #region Serialize Fields

    [Header("Movement")] [SerializeField]private float speed =5f, acceleration = .1f;

    [SerializeField] private Transform _footLocation;
    [SerializeField] private PlayerControlSO controlSo;

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
       RegisterListeners();

    }

    void RegisterListeners()
    {
        controlSo.HandleMovement.AddListener(Movement);
        controlSo.UnequipWeapon.AddListener(UnequipWeapon);
        controlSo.HandleCrouch.AddListener(Crouch);
        controlSo.HandleInteract.AddListener(Interact);
        controlSo.HandleInteract2.AddListener(Interact2);
    }

    void RemoveListeners()
    {
        controlSo.HandleMovement.RemoveListener(Movement);
        controlSo.UnequipWeapon.RemoveListener(UnequipWeapon);
        controlSo.HandleCrouch.RemoveListener(Crouch);
        controlSo.HandleInteract.RemoveListener(Interact);
        controlSo.HandleInteract2.RemoveListener(Interact2);
    }
    

    public void Movement(Vector2 movement)
    {
        _movementDirection = new Vector3(movement.x, 0, movement.y);
        _movementDirection.Normalize();
        _animationController.SetMovement(_movementDirection);
    }

    public void Crouch()
    {
        
    }

    public void Interact()
    {
        
    }

    public void Interact2()
    {
        
    }

    public void UnequipItem()
    {
        
    }

    public void UnequipWeapon()
    {
        
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
