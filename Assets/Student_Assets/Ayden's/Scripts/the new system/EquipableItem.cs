using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItem : MonoBehaviour
{
    private Transform originalPosition;

    private void Start()
    {
        originalPosition = FindObjectOfType<hands>().transform;
        transform.position = originalPosition.position;
        transform.rotation = originalPosition.rotation;
    }
}
