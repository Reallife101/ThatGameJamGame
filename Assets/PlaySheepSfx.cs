using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlaySheepSfx : MonoBehaviour
{
   
  

   FMOD.Studio.EventInstance foundbell;
   FMOD.Studio.EventInstance hidingbell;
   FMOD.Studio.EventInstance runningbell;
   FMOD.Studio.EventInstance sheepbaa;

    
    // Start is called before the first frame update
    void Start()
    {
        
        hidingbell = RuntimeManager.CreateInstance("event:/HidingBell");
        hidingbell.set3DAttributes(RuntimeUtils.To3DAttributes(transform));
        hidingbell.start();
        hidingbell.release();

        sheepbaa = RuntimeManager.CreateInstance("event:/BAAA");
        sheepbaa.set3DAttributes(RuntimeUtils.To3DAttributes(transform));
        sheepbaa.start();
        sheepbaa.release();
    }


   
    public void hidingBell()
    {
        RuntimeManager.PlayOneShotAttached("event:/HidingBell", gameObject);
    }

    public void runningBell()
    {
        runningbell.start();
    }

    public void sheepBaa()
    {
        RuntimeManager.PlayOneShotAttached("event:/BAAA", gameObject);
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
