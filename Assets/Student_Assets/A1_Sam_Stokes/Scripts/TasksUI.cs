using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TasksUI : MonoBehaviour
{
    private TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

   public void UpdateCoinText(TaskManager taskManager)
    {
        coinText.text = taskManager.NumberOfCoins.ToString();
    }
}
