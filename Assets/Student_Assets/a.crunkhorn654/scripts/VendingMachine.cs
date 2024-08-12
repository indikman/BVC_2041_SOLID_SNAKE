using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VendingMachine : MonoBehaviour
{
    public TextMeshProUGUI vendingMachineText;


    public void EatCoin()
    {
        vendingMachineText.text = "it ate your loonie...";
        StartCoroutine(TextTimer());

    }

    IEnumerator TextTimer()
    {
        yield return new WaitForSeconds(6);
       
        vendingMachineText.text = null;

        yield return null;
    }
}
