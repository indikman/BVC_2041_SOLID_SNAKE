using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Code.Scripts.Managers;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class VideoInteractable : Interactable
{
    private VideoPlayer _video;
    public UnityEvent checkEvent;
    protected override void Awake()
    {
        base.Awake();
        _video = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame

    public override void Trigger()
    {
        _playing = !_playing;
        
        if (_playing)
        {
            checkEvent.Invoke();
            _video.Play();
            _video.seekCompleted += (eventHandler) =>
            {
                if (!_playing)
                    return;
                _playing = false;
                InteractEnded?.Invoke();
                
            };
            InteractBegan?.Invoke();
        }
        else
        {
            _video.Stop();
            InteractEnded?.Invoke();
        }
    }
}
