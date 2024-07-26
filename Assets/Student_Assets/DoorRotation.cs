using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorRotate()
    {
        transform.DORotate(new Vector3(-90, 90, 0), 2f, RotateMode.Fast);
    }
}
