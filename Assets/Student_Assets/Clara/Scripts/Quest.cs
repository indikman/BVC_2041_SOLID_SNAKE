using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Quest : ScriptableObject
{
    [System.Serializable]
    public struct Information
    {
        public string name;
        public Sprite icon;
        public string description;
    }

    [Header("Information")] public Information info;

    public bool completed { get; protected set; }
    public QuestCompleted questCompleted;

    public abstract class QuestGoal : ScriptableObject
    {
        protected string _description;
        public int currentPoints { get; protected set; }
        public int requiredPoints = 1;

        public bool completed { get; protected set; }
        public UnityEvent goalCompleted;

        public virtual string GetDescription()
        {
            return _description;
        }
        public virtual void Initialize()
        {
            completed = false;
            goalCompleted = new UnityEvent();
        }
        protected void Evaluate()
        {
            if (currentPoints >= requiredPoints) 
            {
                Complete();
            }
        }
        private void Complete()
        {
            completed = true;
            goalCompleted.Invoke();
            goalCompleted.RemoveAllListeners();
        }
    }
    
    public List<QuestGoal> Goals;

    public void Initialize()
    {
        completed = false;
        questCompleted = new QuestCompleted();

        foreach (var goal in Goals) 
        { 
            goal.Initialize();
            goal.goalCompleted.AddListener(delegate { CheckGoals(); });
        }
    }
    private void CheckGoals()
    {
        completed = Goals.All(x => x.completed);
        if (completed)
        {
            questCompleted.Invoke(this);
            questCompleted.RemoveAllListeners();
        }
    }
}

public class QuestCompleted : UnityEvent<Quest> { }