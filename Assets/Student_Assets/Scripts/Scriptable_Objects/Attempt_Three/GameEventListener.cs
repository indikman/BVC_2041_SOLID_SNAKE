using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    //This will be the event (the variable type is referring to a script named "GameEvent") that this script, GameEventListener, is "listening to"
    public GameEvent event;

    //This event will be called on when "GameEvent" is called on
    public UnityEvent response; 

    private void OnEnable()
    {
        event.RegisterListener(this); //Adding a "listener" (referring to self / this) to "event" 
    }

    private void OnDisable()
    {
        event.RemoveListener(this); //Removing a "listener" (referring to self / this) to "event" 
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}
