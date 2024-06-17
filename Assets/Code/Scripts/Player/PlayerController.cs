using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Inputs;
using Code.Scripts.SOs.Inputs;
using Code.Scripts.SOs.Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour, IPlayerControlListener
{
    #region Serialize Fields
    
    [SerializeField] protected PlayerDataSO playerData;
    [field: SerializeField] public PlayerInteractionsSO PlayerInteractions { get; private set; }
    [SerializeField] private Transform _footLocation;
    [SerializeField] private PlayerControlChannelSO controlChannelSo;
    #endregion
    private Vector3 _movementDirection;
    private Rigidbody _rb;
    private CharacterController _characterController;

    private PlayerAnimationController _animationController;
    private bool _firstListen = true;
    // Start is called before the first frame update
    void Awake()
    {
       _characterController = GetComponent<CharacterController>();
       _animationController = GetComponent<PlayerAnimationController>();
       RegisterListeners();

    }

    public void RegisterListeners() //made these public so they can be called elsewhere - i don't think this is the intended solution!
    {
        controlChannelSo.Movement += Movement;
        controlChannelSo.UnequipWeapon += UnequipWeapon;
        controlChannelSo.Crouch += Crouch;
        controlChannelSo.Interact2 += Interact2;
        if (_firstListen) //this is so you can still interact with things while in cutscenes to prevent softlocks in the back room... it's not a very good solution!
        {
            controlChannelSo.Interact += Interact;
        }
        Debug.Log("listeners registered!");
        _firstListen = false;
    }

    public void RemoveListeners()
    {
        controlChannelSo.Movement -= Movement;
        controlChannelSo.UnequipWeapon -= UnequipWeapon;
        controlChannelSo.Crouch -= Crouch;
        //controlChannelSo.Interact -= Interact;
        controlChannelSo.Interact2 -= Interact2;
        Debug.Log("listeners removed!");
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
        PlayerInteractions.Interact(transform);
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
        _characterController.Move(newMoveDirection * playerData.Speed * Time.fixedDeltaTime);
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
            playerData.Acceleration * Time.fixedDeltaTime);

    }
}
