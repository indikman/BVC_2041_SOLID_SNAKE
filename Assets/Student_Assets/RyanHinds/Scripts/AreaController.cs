using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    [SerializeField] private DoorController[] DoorOpeners;
    
    // Start is called before the first frame update
    public void OpenNewArea(int index)
    {
        DoorOpeners[index].OpenDoor();
    }
}
