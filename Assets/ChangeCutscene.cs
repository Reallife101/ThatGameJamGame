using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCutscene : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToScaredCutscene()
    {
         SceneManager.LoadScene("Cutscene 2");
    }
    public void SwitchToFinalCutscene()
    {
         SceneManager.LoadScene("Cutscene Final");
    }
    public void fadeIn()
    {
        anim.SetTrigger("FadeIn");
    }
}
