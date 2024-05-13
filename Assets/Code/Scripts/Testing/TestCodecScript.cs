using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCodecScript : MonoBehaviour
{
    [SerializeField] private CodecSO testCodec;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RunIt", 2f);
    }

    void RunIt()
    {
        //FindObjectOfType<CodecView>().Initialize(testCodec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
