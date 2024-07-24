using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class InventoryOverlook : MonoBehaviour
{
    //public event Action<bool> pickedUpObject;
    public event Action<bool> objectUsedEvent;

    public void HasObjectBeenUsed(bool hasBeenUsed)
    {
        objectUsedEvent?.Invoke(hasBeenUsed);
    }

    public void UpdatePossession()
    {

    }
}

/*
class CardModel
{
    private string _name;
    private int _strength; 
    private int _dexterity;
    public event Action<int> StrengthChangedEvent, DexterityChangedEvent;
    public string Name{get;set;}
    public int Strength
    {
        get=>_strength;
        set
        {
            _strength = value;
            StrengthChangedEvent?.Invoke(_strength); //relay the message that our strength value has changed
        };
    }
    public int Dexterity
    {
        get=> _dexterity;
        set{
            _dexterity = value;
            DexterityChangedEvent?.Invoke(_dexterity); //send out the event that says, hey, dexterity has changed.
        };
    }
}

class CardController
{
    CardModel model;
    CardView view;
    public CardController()
    {
        view.StrengthPressedEvent += IncStrengthPressed; //so we are now subscribing to our strength pressed event by adding our IncStrengthPressed function (i.e. we're saying "hey, when your event happens, call me)
        view.DexterityPressedEvent += IncDexterityPressed;
        model.StrengthChangedEvent += StrengthValueChanged; //subscribe to events on the model as well.
        model.DexterityChangedEvent += DexterityValueChanged;
    }
    private void IncStrengthPressed(int value) //this has to be of a return type void, and take in a parameter of a single integer because the event type is Action<int>; i.e. void some_name(int some_parameter)
    {
        model.Strength += value;
    }
    private void IncDexterityPressed(int value)
    {
        model.Dexterity += value;
    }
    private void StrengthValueChanged(int value)
    {
        view.UpdateStrength(value); //when we have the model change and this function is called (through the event), we update the view
    }
    private void DexterityValueChanged(int value)
    {
        view.UpdateDexterity(value);
    }

}

class CardView
{
    // private int _strength, _dexterity; //we do not need the local value for these
    // private string _name;
    public event Action<int> StrengthPressedEvent; //an event is of the following type: "event <delegate> <event_name>"
    public event Action<int> DexterityPressedEvent;//An "Action<int>" means what? 
    //What's a delegate?
    //A delegate is a function pointer. It means that you are pointing to a particular function of a particular signature. Any function of a certain return type and a certain set of parameters
    //"Action" is a built in delegate type for C#. This is specifying the return type for a delegate. What return type is that? void. An Action is a void function
    //public delegate void SomeFunction(int value);, this is a delegate that is a void function that takes in one integer parameter.
    //When specifying something as a delegate, it means you can replace this with any function that has a void return type and takes in a single integer.
    //You cannot replace this with some other function.
    //The <int> is because it's a generic, and this specifies the parameter types. If you had Action<int, int>, any function pointer would have to be void and take in two parameters, both of which are ints. If Action<int, string, float> any function pointer would have to be void and take in three parameters: int, string, and float 
    //If we see UnityEvent, this is essentially the same as "event Action", so a UnityEvent requires a void function. UnityEvent<int> is a void function with one parameter that is an integer, and UnityEvent<int, string, float>, same as above with int, string, and float parameters
    public void UpdateStrength(int strValue)
    {

    }

    public void UpdateDexterity(int dexValue)
    {

    }
    public void UpdateName(string nameValue)
    {

    }

    public void IncStrengthPressed(int value) //imagine this happens if our strength is clicked (positive or negative)
    {
        //what happens if we have a local strength value and, when we click this button, it increases that local value?
        //does this update any other view? No.
        //we do not know in our view if any other views need that information. Hence, we don't know if the model needs to change for them...
        StrengthPressedEvent?.Invoke(value); //for an event, we Invoke it. This means we send out an event with the parameter. This means that anything that listens to our event can then do something with the event.
    }
    
    public void IncDexterityPressed(int value) //imagine this happens if our dexterity is clicked (positive or negative)
    {
        DexterityPressedEvent?.Invoke(value); //The ? is done as a null check to make sure that we actually have a listener.
        //A delegate calls functions. An event essentially is calling a bunch of functions of its delegate type. So what we really mean when something listens for an event, is we register a function with that event to be called when the event is invoked.
    }
}
*/
