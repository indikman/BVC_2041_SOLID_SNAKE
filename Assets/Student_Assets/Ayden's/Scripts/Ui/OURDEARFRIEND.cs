using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SayThings(); //This is the delegate type for the event that you're going to make 
public class OURDEARFRIEND : MonoBehaviour
{
    FunEvent funEvent = new FunEvent();
    public void Start()
    {
        funEvent.internalEvent += ReactionToFun; //Subscribe to the type SayThings via the delegate, and register the handler for it to be ReactionToFun(); 
        funEvent.internalEvent += AnotherReactionToFun;
        
    }

    public void OnClick()
    {
        funEvent.Run();
    }

    /// <summary>
    /// In which we receive the FunEvent and react to it. Poorly? 
    /// </summary>
    private void ReactionToFun()
    {
        Debug.Log("You fuck, how dare you have fun.");
    }

    private void AnotherReactionToFun()
    {
        Debug.Log("I, personally, think that the fun is quite nice.");
    }
    
}




/// <summary>
/// An event class in which we have fun. 
/// </summary>
public class FunEvent
{
    public event SayThings internalEvent; //declare the event 

    public void Run()
    {
        DoTheFun(); 
    }

    protected virtual void DoTheFun()
    {
        Debug.Log("We are actually doing the fun");
        internalEvent?.Invoke(); //If not null, we call all event handler methods that are registered to this particular event. 
    }
}
