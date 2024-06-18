using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create_A_Task_For_The_Player", menuName = "Siena SO's/Give A Task to the Player", order = 1)]
public class CollectionOfTasks : ScriptableObject
{
    public List<IndividualTask> task = new List<IndividualTask>();
}
