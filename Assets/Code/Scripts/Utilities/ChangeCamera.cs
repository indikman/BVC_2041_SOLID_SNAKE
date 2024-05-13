using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Managers;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private string cameraName;

    public void SetCamera()
    {
        CameraManager.Instance.EnableCamera(cameraName);
    }
}
