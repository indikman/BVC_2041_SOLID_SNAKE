using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Inputs;
using Code.Scripts.Managers;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Yes, this is going to be a bad way to do things; no, I do not think we should use this. Yes, you will fix it.
/// </summary>
/// 
public class CodecEvent : MonoBehaviour
{
    [Header("Codec Parts"), SerializeField]
    protected CodecSO codecData;
    [SerializeField] protected CodecSettingsSO codecSettings;
    public UnityEvent EventTrigerred;
    public UnityEvent CodecComplete;
    public PlayerController pC;
    public GameObject mainDoor;
    public GameObject altDoor;
    public float doorspeed;


    protected virtual void Awake()
    {

        Invoke("Trigger", 5.0f);
    }
    public virtual void Trigger()
    {
        GameObject prefabObject = Instantiate(codecSettings.CodecPrefab);
        prefabObject.GetComponent<CodecView>().Initialize(codecData, codecSettings);
        EventTrigerred?.Invoke();
        pC.RemoveListeners();
        prefabObject.GetComponent<CodecView>().CodecComplete.AddListener(()=>CodecComplete?.Invoke());
        CodecComplete.AddListener(moveReEnable);


    }
   
    public IEnumerator doorChange()
    {
        yield return new WaitForSeconds(doorspeed);
        mainDoor.transform.Rotate(0, 0, 15);
        altDoor.transform.Rotate(0, 0, 15);
        yield return new WaitForSeconds(doorspeed);
        mainDoor.transform.Rotate(0, 0, 15);
        altDoor.transform.Rotate(0, 0, 15);

        yield return new WaitForSeconds(doorspeed);
        mainDoor.transform.Rotate(0, 0, 15);
        altDoor.transform.Rotate(0, 0, 15);

        yield return new WaitForSeconds(doorspeed);
        mainDoor.transform.Rotate(0, 0, 15);
        altDoor.transform.Rotate(0, 0, 15);

        yield return new WaitForSeconds(doorspeed);
        mainDoor.transform.Rotate(0, 0, 15);
        altDoor.transform.Rotate(0, 0, 15);

        yield return new WaitForSeconds(doorspeed);
        mainDoor.transform.Rotate(0, 0, 15);
        altDoor.transform.Rotate(0, 0, 15);

        yield return null;
    }
    void moveReEnable()
    {
        pC.RegisterListeners();
        StartCoroutine(doorChange());
    }

    // Start is called before the first frame update
    void Start()
    {
        // _audioSource = GetComponent<AudioSource>();
        // _audioSource.clip = codecSettings.RingingSFX;
        // Invoke("Activate", 5f);
        // CameraManager.Instance.EnableCamera(cameraName);
    }
    

    // Update is called once per frame

}
