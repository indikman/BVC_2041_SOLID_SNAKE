using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "Quest", menuName = "SOs/Clara/Quest", order = 1)]
public class Quest : ScriptableObject
{
    public List<IndividualTasks> tasks = new List<IndividualTasks>();

    // Could add the sound clip here as an audio clip

    //[Header("Information")] public TaskInformation info;
}
    