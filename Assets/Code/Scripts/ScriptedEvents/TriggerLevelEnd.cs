using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class TriggerLevelEnd : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private string _nextScene;
    private void Awake()
    {
        _director = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            _director.Play();
            _director.played += (val) => SceneManager.LoadScene(_nextScene);
        }
    }
}
