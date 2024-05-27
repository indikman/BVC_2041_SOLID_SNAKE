using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Managers;
using UnityEngine;
using UnityEngine.Serialization;

public class TriggerCodecEvent : CodecEvent
{
    // Start is called before the first frame update
    protected override void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            GameObject prefabObject = Instantiate(codecSettings.CodecPrefab);
            prefabObject.GetComponent<CodecView>().Initialize(codecData, codecSettings);
            EventTrigerred?.Invoke();
            prefabObject.GetComponent<CodecView>().CodecComplete.AddListener(()=>CodecComplete?.Invoke());
            Destroy(this.GetComponent<Collider>());
        }

    }
}
