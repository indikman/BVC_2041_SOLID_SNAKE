using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Managers;
using UnityEngine;
using UnityEngine.Serialization;

public class TriggerCodecEvent : CodecEvent
{
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = codecSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Activate()
    {
        Active = true;
    }

    public override void OpenCall()
    {
        if (!_active)
            return;
        base.OpenCall();
        
        itemToOpen.gameObject.SetActive(!itemToOpen.gameObject.activeInHierarchy);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            CameraManager.Instance.EnableCamera(cameraName);
            itemToOpen.gameObject.SetActive(!itemToOpen.gameObject.activeInHierarchy);
            Invoke("Activate", 5f);
            Destroy(this.GetComponent<Collider>());
        }
    }
}
