using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlaySfx : MonoBehaviour
{
   
   FMOD.Studio.EventInstance footsteps;
   FMOD.Studio.EventInstance petSheep;

   FMOD.Studio.EventInstance foundbell;
   FMOD.Studio.EventInstance hidingbell;

    

    // Start is called before the first frame update
    void Start()
    {
        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
        petSheep = FMODUnity.RuntimeManager.CreateInstance("event:/Pet");
        foundbell = FMODUnity.RuntimeManager.CreateInstance("event:/FoundBell");
        hidingbell = FMODUnity.RuntimeManager.CreateInstance("event:/HidingBell");
    }
    

    public void stepSound()
    {
        footsteps.start();
    }

    public void petSound()
    {
        petSheep.start();
    }
     public void foundBell()
    {
        foundbell.start();
    }
    public void hidingBell()
    {
        hidingbell.start();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
