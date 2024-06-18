using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
  public int NumberOfCoins {  get; private set; }

  public UnityEvent<TaskManager> OnCoinsCollected;

  public void CoinsCollected()
    {
        NumberOfCoins++;
        OnCoinsCollected.Invoke(this);

    }
}
