using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Managers;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource _source;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    
    public void PlaySoundEffect(AudioClip clip)
    {
        if (clip == null) return;

        if (_source == null) return;
        
        _source.clip = clip;
        _source.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip, bool isLooped, GameObject targetSource)
    {
        if (clip == null)  return;

        AudioSource source = targetSource.GetComponent<AudioSource>();

        if (source == null) return;

        source.clip = clip;
        source.loop = isLooped;
        source.Play();
    }
}
