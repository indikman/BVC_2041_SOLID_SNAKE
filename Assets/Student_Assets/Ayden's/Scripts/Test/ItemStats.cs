using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemStats : MonoBehaviour
{
    //public TMP_Text Text;
    public TMP_Text countText;
    [SerializeField] private int joe = 1;
    public bool enabled;
    public string Fuck = "fuck-";

    private void Awake()
    {
        //Text = GetComponent<TMP_Text>();
        //countText = GetComponent<TMP_Text>();
        
        //Text.SetText(_itemSo.Description);
        //countText.text = (joe.ToString());
        //count = 1;
        joe = 1;
        if (joe != 1)
        {
          Debug.Log ("fucking scream and die");
          joe = 1;
        }
    }
    public void IncreaseCount()
    {
        Joe();
        Debug.Log("Beginning of offfffffff IncreaseCount() is " + joe);
        //count++;
        //Debug.Log(count);
        // countText.text = count.ToString();

        Fuck = Fuck + Fuck;
        Debug.Log("End of IncreaseCount() is " + joe);
    }

    void Joe()
    {
        joe++;
    }

    private void FixedUpdate()
    {
    }
}


