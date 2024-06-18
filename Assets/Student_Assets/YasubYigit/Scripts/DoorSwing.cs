using UnityEngine;
using DG.Tweening;

public class DoorSwing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Door triggered");
        transform.DOLocalRotate(new Vector3(-90, 0, -90), 1.0f);
    }
}
