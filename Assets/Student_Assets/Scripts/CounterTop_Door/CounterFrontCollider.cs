using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterFrontCollider : MonoBehaviour
{
    [SerializeField]
    CounterDoorMovement counterDoorMovement; //"CounterDoorMovement" script

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player"))
        {
            counterDoorMovement.GrabDoorCollision(true);
            counterDoorMovement.GrabPlayerPosition(collider.gameObject.transform.position); //Giving the position of the collider with the tag "Player" to the "CounterDoorMovement" script
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player"))
            counterDoorMovement.GrabDoorCollision(false);
    }
}
