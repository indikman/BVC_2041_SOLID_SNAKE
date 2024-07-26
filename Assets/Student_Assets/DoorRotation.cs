using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using DG.Tweening;
using Vector3 = UnityEngine.Vector3;

public class DoorRotation : MonoBehaviour
{
    [SerializeField] private Vector3 openedPosition;

    [SerializeField] private Vector3 closedPosition;

    [SerializeField] private float doorSpeed = 10f;

    [SerializeField] private Vector3 startingPosition;

    [SerializeField] private bool isOpened;
    // Start is called before the first frame update
    // Thank you to Ryan / AngelusNein for assistance.
    // using comments to show understanding and not just copypasting lol
    
    private void Awake()
    {
        //On awake, the door sets its current position into a variable
        startingPosition = transform.position;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorRotate()
    {
        // Door opens by taking the vars and pumping them into DOrotate from DOTWEEN
        transform.DORotate(new Vector3(-90, 90, 0), 10f, RotateMode.Fast);
    }
}
