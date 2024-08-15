using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    public Image slot1;
    public Image slot2;
    public Image slot3;

    public Sprite sprite1;
    public Sprite sprite2;  
    public Sprite sprite3;

    public void Start()
    {
        slot1.sprite = sprite1; //This Funtion lets the Sprite be the same whereas OVER RIDE funtion lets you swap the image 
        slot2.sprite = sprite2; 
        slot3.sprite = sprite3; 
    }
}
