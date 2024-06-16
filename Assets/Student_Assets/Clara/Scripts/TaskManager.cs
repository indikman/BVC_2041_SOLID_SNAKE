using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public Quest quest;
    public PlayerController player;
    public Text questName;
    public Text questDescription;

    public void QuestWindow()
    {
        questName.text = quest.name;
        questDescription.text = quest.info.description;
    }
}
