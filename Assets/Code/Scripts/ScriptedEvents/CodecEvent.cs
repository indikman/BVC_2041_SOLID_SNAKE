using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Managers;
using UnityEditor.Timeline.Actions;
using UnityEngine;

/// <summary>
/// Yes, this is going to be a bad way to do things; no, I do not think we should use this. Yes, you will fix it.
/// </summary>
public class CodecEvent : MonoBehaviour
{
    protected bool _active = false;
    [Header("Codec Parts"), SerializeField]
    protected GameObject codecPrefab;
    [SerializeField]
    protected CodecSO codecData;
    [SerializeField]
    protected AudioClip codecSound;
    [SerializeField] private GameObject tabText;
    [SerializeField] protected GameObject itemToOpen;  
    [SerializeField] protected string cameraName;
    protected AudioSource _audioSource;
    
    public bool Active
    {
        get
        {
            return _active;
        }
        set
        {
            _active = value;
            if(_active)
                _audioSource.Play();
            else
                _audioSource.Stop();
        }
    }
    

    public virtual void OpenCall()
    {
        if (!_active)
            return;
        Active = false;
        GameObject prefabObject = Instantiate(codecPrefab);
        prefabObject.GetComponent<CodecView>().Initialize(codecData);
        if(itemToOpen!= null)
            itemToOpen.gameObject.SetActive(!itemToOpen.gameObject.activeInHierarchy); //let's swap the door.
        Destroy(this.gameObject, 1f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = codecSound;
        Invoke("Activate", 5f);
        CameraManager.Instance.EnableCamera(cameraName);
    }

    protected virtual void Activate()
    {
        if(tabText != null)
            tabText.SetActive(true);
        Active = true;
    }

    // Update is called once per frame

}
