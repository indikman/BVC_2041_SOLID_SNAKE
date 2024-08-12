using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager :TaskManager
{
    public Light lightControl;
    // Start is called before the first frame update
    void Start()
    {
        lightControl.enabled = false;
    }

    public override void DoTask()
    {
        base.DoTask();
        LightON();
    }
    // Update is called once per frame
    public void LightON()
    {
        lightControl.enabled= true; 
    }
}
