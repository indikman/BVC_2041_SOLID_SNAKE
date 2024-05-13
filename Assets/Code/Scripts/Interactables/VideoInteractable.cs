using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoInteractable : Interactable
{
    private VideoPlayer _video;
    void Awake()
    {
        _video = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Trigger()
    {
        _video.Play();
    }
}
