using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSnake : MonoBehaviour //This Script will allow the player to stop moving snake during COM scenes
{
  [SerializeField] private PlayerController _playerController;
  [SerializeField] private Animator _playerAnimation; 
  void Update()
  {
    if (Input.GetKey(KeyCode.Tab))
    {
      _playerController.enabled = false;
      _playerAnimation.enabled = false;
    }
    else if (Input.GetKey((KeyCode.Return)))
    {
      _playerController.enabled = true;
      _playerAnimation.enabled = true;
    }
  }
}
