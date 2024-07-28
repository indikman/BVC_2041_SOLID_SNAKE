using UnityEngine;
using UnityEngine.UI;

public class StaticInteractables : MonoBehaviour
{
    public UI_Inventory uiItem;
    public GameObject itemActivity;
    public Button button;


    private bool _objectActive;
    private float _durationTime = 2.0f;
    
    public void Start()
    {
        button.GetComponent<Button>(); //This makes the loonies unusable UNTIL snake gets close to the counter and washing machine
        button.enabled = false;
        
    }
    
    public void Update()
    {

        uiItem.ItemUsedEvent += LoonieUsed;
    }
    
    public void OnTriggerEnter(Collider other)
    {
       if(other.GetComponent<Collider>().gameObject.CompareTag("Player") &&  _objectActive == false)
       {
           button.enabled = true; //This makes the loonies usable UNTIL snake gets close to the washing and /or counter.
       }
       _objectActive = true;
        
    }
    
    private void LoonieUsed (bool value)
    {
        if(value == true)
        {
           itemActivity.SetActive(true);
           Destroy(itemActivity, _durationTime);
            
        }
    }
}

