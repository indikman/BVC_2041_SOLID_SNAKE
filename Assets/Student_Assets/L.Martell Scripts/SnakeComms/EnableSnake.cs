using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSnake : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator playerAnimation;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        playerController.enabled = true;
        
    }
    
}
