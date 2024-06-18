using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteractable : Interactable
{
    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
    }
    public override void Trigger()
    {
        _playing = !_playing;
        
        if (_playing)
        {
            StartCoroutine(PlayAudioUntilEnd());
        }
        else
        {
            StopAllCoroutines();
            _playing = false;
            _audioSource.Stop();
            enablePlayerControl.Invoke();
            InteractEnded?.Invoke();
        }
    }

    IEnumerator PlayAudioUntilEnd()
    {
        _audioSource.Play();
        disablePlayerControl.Invoke();
        InteractBegan.Invoke();
        yield return new WaitForSeconds(_audioSource.clip.length);
        _playing = false;
        enablePlayerControl.Invoke();
        InteractEnded?.Invoke();

    }
}
