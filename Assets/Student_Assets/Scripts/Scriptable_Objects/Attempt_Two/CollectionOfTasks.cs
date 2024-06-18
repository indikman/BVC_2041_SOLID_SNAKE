using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create_A_Task_For_The_Player", menuName = "Give A Task to the Player")]
public class CollectionOfTasks : ScriptableObject
{
    public List<Individual_Task> task = new List<Individual_Task>();

}
