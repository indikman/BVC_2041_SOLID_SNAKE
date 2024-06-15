using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextVisability : MonoBehaviour
{
    private TextMeshProUGUI textElement; // Reference to the TextMeshPro component
    public bool isTextVisible = false; // Boolean flag to control visibility

    void Awake()
    {
        // Get the TextMeshPro component attached to this GameObject
        textElement = GetComponent<TextMeshProUGUI>();

        // Ensure the text starts as inactive
        SetTextVisibility(isTextVisible);
    }

    // Method to set text visibility
    public void SetTextVisibility(bool isVisible)
    {
        textElement.gameObject.SetActive(isVisible);
    }

    // Example method to toggle visibility
    public void ToggleTextVisibility()
    {
        isTextVisible = !isTextVisible;
        SetTextVisibility(isTextVisible);
    }
}
