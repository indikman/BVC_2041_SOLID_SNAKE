using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TV : Quest.QuestGoal
{
    public string watchTV;

    public override string GetDescription()
    {
        return $"Watch the TV";
    }
    public override void Initialize()
    {
        base.Initialize();
        //EventSystem.Instance.AddListener();
    }
}
