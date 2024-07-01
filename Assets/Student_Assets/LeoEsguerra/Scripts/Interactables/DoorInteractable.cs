using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorInteractable : Interactable
{
    [SerializeField] private bool _isOpen = false;
    [SerializeField] private Vector3 _openRotation = new Vector3(0, 90, 0);
    [SerializeField] private Vector3 _closedRotation;

    private bool isMoving = false;
    protected override void Awake()
    {
        base.Awake();
        if(_isOpen)
        {
            _openRotation = transform.localEulerAngles;
        }
        else
        {
            _closedRotation = transform.localEulerAngles;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Trigger()
    {
        Debug.Log("Triggered");
        base.Trigger();

        if(isMoving)
        {
            return;
        }

        isMoving = true;
        transform.DOLocalRotate(_isOpen ? _closedRotation : _openRotation, 1).onComplete += () =>
        {
            isMoving = false;
            _isOpen = !_isOpen;
        };
    }
}
