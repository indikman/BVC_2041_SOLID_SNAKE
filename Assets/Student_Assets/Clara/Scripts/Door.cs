using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpening = false;
    public GameObject door;

    private void Update()
    {
        if (Input.GetKeyDown("h"))
            OpenDoor();
    }
    public void OpenDoor()
    {
        if (!isOpening)
        {
            door.transform.Rotate(0, 90, 0);
            isOpening = true;
        }
    }
    public void CloseDoor()
    {
        door.transform.Rotate(0, 0, 0);
        isOpening = false;
    }
}