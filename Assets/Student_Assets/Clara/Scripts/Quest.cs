using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "Quest", menuName = "SOs/Clara/Quest", order = 1)]
public class Quest : ScriptableObject
{
    public bool isActive;
    public bool completed;
    public UnityAction EventTrigger;

    [System.Serializable]
    public struct Information
    {
        public string name;
        public Sprite icon;
        public string description;
    }

    [Header("Information")] public Information info;

    public void StartTask()
    {
        EventTrigger.Invoke();
    }    
}
