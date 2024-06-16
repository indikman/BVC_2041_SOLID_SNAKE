using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public float open = 100f;
    public float range = 10f;

    public GameObject door;
    public bool isOpening = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            StartCoroutine(OpenDoor());
        }
    }
    IEnumerator OpenDoor()
    {
        isOpening = true;
        door.GetComponent<Animator>().Play("DoorOpen");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(5.0f);
        door.GetComponent<Animator>().Play("Door");
        isOpening = false;
    }
}
