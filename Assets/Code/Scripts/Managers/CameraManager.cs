using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Code.Scripts.Managers;
using UnityEngine;

namespace Code.Scripts.Managers
{
    public class CameraManager : Singleton<CameraManager>
    {
        private CinemachineBrain _brain;
        // Start is called before the first frame update
        private Dictionary<String, CinemachineVirtualCamera> cameras =
            new Dictionary<string, CinemachineVirtualCamera>();
            /// <summary>
            /// Thing to note: all of our cameras need to be on to be initialized. Unfortunately, if we do not do this, the disabled ones will not show up
            /// </summary>
        protected override void Initialize()
        {
            _brain = Camera.main.GetComponent<CinemachineBrain>();
            cameras.Clear();
            CinemachineVirtualCamera[] sceneCameras = FindObjectsOfType<CinemachineVirtualCamera>();
            foreach (CinemachineVirtualCamera cam in sceneCameras)
            {
                cameras[cam.name] = cam;
            }

            _brain.m_CameraActivatedEvent.AddListener(DisableOtherCameras);
        }

        private void DisableOtherCameras(ICinemachineCamera cam1, ICinemachineCamera cam2)
        {
            foreach (KeyValuePair<String,CinemachineVirtualCamera> cam in cameras)
            {
                if (cam.Value.gameObject != cam1.VirtualCameraGameObject)
                {
                    cam.Value.gameObject.SetActive(false);
                }
            }
        }
        
        public void EnableCamera(string name)
        {
            var newCamera = cameras[name];
            if (newCamera == null)
            {
                Debug.Log("Camera does not exist");
                return;
            }
            newCamera.gameObject.SetActive(true);
            foreach (KeyValuePair<string,CinemachineVirtualCamera> cam in cameras)
            {
                if(cam.Value != newCamera)
                    cam.Value.gameObject.SetActive(false);
            }
        } 
        // Update is called once per frame
        void Update()
        {

        }
    }
}
