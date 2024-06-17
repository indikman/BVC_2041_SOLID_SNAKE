using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Code.Scripts.Managers;
using UnityEngine;
using UnityEngine.Video;

public class VideoInteractable : Interactable
{
    private VideoPlayer _video;
    private TaskManager _taskManager;
    private IndividualTasks _tasks;
    
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
            _tasks.isCompleted = true;
        }
    }
}
