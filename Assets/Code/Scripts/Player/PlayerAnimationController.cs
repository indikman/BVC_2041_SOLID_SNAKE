using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMovement(Vector3 movementVector)
    {
        _animator.SetBool("isRunning", movementVector.magnitude > 0.1f);
    }
}
