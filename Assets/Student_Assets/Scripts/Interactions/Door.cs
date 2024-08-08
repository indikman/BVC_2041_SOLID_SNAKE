using UnityEngine;

public class Door : MonoBehaviour
{
    public float openAngle = 90f;  // Angle to open the door
    public float openSpeed = 2f;   // Speed of opening the door
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen = false;

    private void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);
        }
    }
}