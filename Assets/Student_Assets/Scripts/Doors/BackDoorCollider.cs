using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDoorCollider : MonoBehaviour
{
    [SerializeField]
    DoorMovement doorMovement; //"DoorMovement" script

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player"))
        {
            doorMovement.GrabDoorCollision(true);
            doorMovement.GrabPlayerPosition(collider.gameObject.transform.position); //Giving the position of the collider with the tag "Player" to the "DoorMovement" script
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player"))
            doorMovement.GrabDoorCollision(false);
    }
}
