using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> eventListeners = new List<GameEventListener>();
    //Anything inside the <,> will be a variable type. This could be a script class name (example being this script's class being named "GameEvent"), an int, a string, whatever.
    //Creating a list of listeners to this script that will respond / call back to this event

    public void RegisterListener(GameEventListener listener)
    {
        eventListeners.Add(listener); //Adding a "listener" to the list called "eventListener"
    }

    public void RemoveListener(GameEventListener listener)
    {
        eventListeners.Remove(listener); //Removing a "listener" to the list called "eventListener"
    }

    public void Raise()
    {
        for(int i = eventListeners.Count-1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(); //This is now calling the "GameEventListener" script at "OnEventRaised" method
        }
    }
}