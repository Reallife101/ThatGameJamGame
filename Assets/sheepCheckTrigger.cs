using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SheepCheckTrigger : MonoBehaviour
{
    public Animator anim;
    public playerController playerController;
    public Image sceneFadeImage;
    public Animator uiAnim;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        //playerController = GetComponent<playerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (!HasDisabledSheep())
        {
            OnNoDisabledSheepFound();
        }

    }

    private bool HasDisabledSheep()
    {
        GameObject[] sheep = GameObject.FindGameObjectsWithTag("Sheep");

        foreach (GameObject s in sheep)
        {
            ChasePlayerNavMesh chase = s.GetComponent<ChasePlayerNavMesh>();

            // We only care about sheep that HAVE the component and it is DISABLED
            if (chase != null && !chase.enabled)
            {
                return true;
            }
        }

        return false;
    }

    private void OnNoDisabledSheepFound()
    {
        Debug.Log("Trigger End Stuff");
        anim.SetTrigger("TransformCutscene");
        playerController.DisableMovement();
        uiAnim.SetTrigger("FadeIn");
    }
}
