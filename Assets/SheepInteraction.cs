using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SheepInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject UIBillboard;

    [Header("Events")]
    [SerializeField] private UnityEvent onInteracted;

    [SerializeField] private GameObject healVFX;

    private ChasePlayerNavMesh cpnm;

    private Animator anim;

    private bool hasBeenInteracted = false;

    private void Start()
    {
        cpnm = GetComponent<ChasePlayerNavMesh>();

        if (cpnm != null)
            cpnm.enabled = false;

        anim = GetComponentInChildren<Animator>();
    }

    void IInteractable.Interact()
    {
        if(hasBeenInteracted)
        {
            anim.SetTrigger("petTrigger");
            return;
        }

        Debug.Log("I AM A SHEEP THAT HAS BEEN PETTED");
        hasBeenInteracted = true;
        // Enable chase ONLY if component exists
        if (cpnm != null)
            cpnm.enabled = true;

        // Fire event to ALL listeners
        onInteracted?.Invoke();
    }

    void IInteractable.SetUIActive(bool b)
    {
        // If there's no chase component, always allow UI
        if (cpnm == null)
        {
            UIBillboard.SetActive(b);
            return;
        }

        // Original behavior preserved
        if (!cpnm.enabled)
        {
            UIBillboard.SetActive(b);
        }
        else
        {
            UIBillboard.SetActive(false);
        }
    }

    public void AnimWakeUp()
    {
        anim.SetBool("isAwake", true);
    }

    public void PlayHealVFX()
    {
        Instantiate(healVFX, transform.position, transform.rotation);
    }
    
}
