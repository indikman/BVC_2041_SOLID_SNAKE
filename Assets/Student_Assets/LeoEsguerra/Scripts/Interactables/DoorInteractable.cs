using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorInteractable : Interactable
{
    [SerializeField] private bool _isOpen = false;
    [SerializeField] private Vector3 _openRotation = new Vector3(0, 90, 0);
    [SerializeField] private Vector3 _closedRotation = new Vector3(0, 0, 0);

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
        base.Trigger();
        if(_isOpen)
        {
            transform.DOLocalRotate(_closedRotation, 1);
        }
        else
        {
            transform.DOLocalRotate(_openRotation, 1);
        }
    }
}
