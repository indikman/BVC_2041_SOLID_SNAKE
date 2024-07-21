using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "taskList", menuName = "A1/TaskList", order = 1)] //A1 so if I mess up, i can know where from...
public class PlayerTaskList : ScriptableObject
{
    public List<IndividualTask> task = new List<IndividualTask>();
}
