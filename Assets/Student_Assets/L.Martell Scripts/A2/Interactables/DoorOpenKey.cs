using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpenKey : MonoBehaviour
{
   public Button button;
   public UI_Inventory uiItem;
   
   
   public float openTime = 3.0f;


   private bool _openDoorWithKey;

   public void Start()
   {
      button.GetComponent<Button>(); //This makes the key unusable UNTIL snake gets close to the door.
      button.enabled = false;
   }

   private IEnumerator DoorOpens()
   {
      Quaternion startRotation = transform.rotation;
      Quaternion endRotation;
         
      endRotation = Quaternion.Euler(new Vector3(-90f,0f,90f));
      float time = 0;

      while (time < 1)
      {
         transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
         yield return null;
         time += Time.fixedDeltaTime * openTime;
      }

   }
   public void FixedUpdate()
   {
      uiItem.ItemUsedEvent += DoorOpen;
   }

   public void OnTriggerEnter(Collider other)
   {
      if (other.GetComponent<Collider>().gameObject.CompareTag("Player") && _openDoorWithKey == false)
      {
         button.enabled = true; //This makes the key usable UNTIL snake gets close to the door.
      }

      _openDoorWithKey = true;
   }

   private void DoorOpen(bool value)
   {
      if (value == true && _openDoorWithKey == true)
         StartCoroutine(DoorOpens());

   }
  // I tried using " != " when needed, but that messed up my results, I don't know why, so i went with " == " instead, which isn't objectively bad, but I don't like it
   
   
   
}
