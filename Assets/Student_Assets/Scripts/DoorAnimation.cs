using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
   
    public void PlayOpenAnimation()
    {
       animator.SetBool("Open", true);
    }
    public void PlayClosingAnimation()
    {
        animator.SetBool("Open", false);
    }

}
