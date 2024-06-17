using System.Collections;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    [SerializeField] Direction direction;
    enum Direction
    {
        y, z
    }

    bool isDoorOpen = false;

    public void OpenCloseDoor()
    {
        if (!isDoorOpen)
        {
            StartCoroutine(OpenDoor());
            isDoorOpen = true;
        }
        else
        {
            StartCoroutine(CloseDoor());
            isDoorOpen = false;
        }
    }

    IEnumerator OpenDoor()
    {
        if(direction == Direction.y)
            this.transform.Rotate(0, 90, 0);
        else if (direction == Direction.z)
            this.transform.Rotate(0, 0, -90);
        yield return null;
    }

    IEnumerator CloseDoor()
    {
        if (direction == Direction.y)
            this.transform.Rotate(0, -90, 0);
        else if (direction == Direction.z)
            this.transform.Rotate(0, 0, 90);  
        yield return null;
    }
}
