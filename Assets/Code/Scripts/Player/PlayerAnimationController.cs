using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMovement(Vector3 movementVector)
    {
        _animator.SetBool("isRunning", movementVector.magnitude > 0.1f);
    }
}
