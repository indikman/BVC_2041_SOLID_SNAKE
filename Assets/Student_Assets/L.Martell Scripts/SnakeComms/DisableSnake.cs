using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSnake : MonoBehaviour //This Script will allow the player to stop moving snake during COM scenes
{
  [SerializeField] private PlayerController playerController;

  [SerializeField] private Animator playerAnimation;

  private void Start()
  {
    playerAnimation.SetBool("isRunning",  false);
  }

  private void FixedUpdate()
  {
    StartCoroutine(StopRunning());
  }

  private IEnumerator StopRunning()
  {
    yield return new WaitForSeconds(5);
    {
      playerController.enabled = false;
      playerAnimation.SetBool("isRunning",  false);
      yield return null;
    }
    
    
  }
  
}


