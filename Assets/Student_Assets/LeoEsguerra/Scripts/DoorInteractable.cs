using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.SOs.Player;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class DoorInteractable : Interactable
{
    [SerializeField] private bool _isOpen = false;
    [SerializeField] private float _rotationDuration = 1.0f;
    [SerializeField] private Vector3 _closedRotation;
    [SerializeField] private Vector3 _openRotation;
    
    protected override void Awake()
    {
        base.Awake();

        // check the initial state of the door and rotation
        if(!_isOpen)
        {
            _closedRotation = transform.localEulerAngles;
        }
        else
        {
            _openRotation = transform.localEulerAngles;
        }
    }
    
    // Swing the door open or closed using DoTween
    public override void Trigger()
    {
        _playing = !_playing;
        
        if (_playing)
        {
            if (!_isOpen)
            {
                _isOpen = true;
                transform.DOLocalRotate(_openRotation, _rotationDuration).OnComplete(() =>
                {
                    _playing = false;
                    InteractEnded?.Invoke();
                });
            }
            else
            {
                _isOpen = false;
                transform.DOLocalRotate(_closedRotation, _rotationDuration).OnComplete(() =>
                {
                    _playing = false;
                    InteractEnded?.Invoke();
                });
            }

            InteractBegan?.Invoke();
        }
        else
        {
            InteractEnded?.Invoke();
        }
    }
}
