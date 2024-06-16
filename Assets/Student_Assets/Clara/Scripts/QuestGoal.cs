using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public abstract class QuestGoal : Quest
{
    public int currentPoints;
    public int requiredPoints = 1;
    public List<Quest> quests {  get; set; } = new List<Quest>();

    public UnityEvent goalCompleted;
    public void CheckGoals()
    {
        completed = quests.All(g => g.completed);
    }
    public virtual void Initialize()
    {

    }
    public void Evaluate ()
    {
        if(currentPoints >= requiredPoints) 
        {
            Complete();
        }
    }
    public void Complete()
    {
        completed = true;
        isActive = false;
    }
}

