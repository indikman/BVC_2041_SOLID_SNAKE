using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TextVisability : MonoBehaviour
{
    private TextMeshProUGUI textElement; 
    public bool isTextVisible = false;
    public UnityEvent checkEvent;
    void Awake()
    {
    
        textElement = GetComponent<TextMeshProUGUI>();

 
        SetTextVisibility(isTextVisible);
    }

   
    public void SetTextVisibility(bool isVisible)
    {
        textElement.gameObject.SetActive(isVisible);
    }

    
    public void ToggleTextVisibility()
    {
        isTextVisible = !isTextVisible;
        SetTextVisibility(isTextVisible);
        checkEvent.Invoke();
    }
}
