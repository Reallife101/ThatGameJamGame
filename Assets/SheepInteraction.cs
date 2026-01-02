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

    private void Start()
    {
        cpnm = GetComponent<ChasePlayerNavMesh>();
        cpnm.enabled = false;
        anim = GetComponentInChildren<Animator>();
    }

    void IInteractable.Interact()
    {
        if(cpnm.enabled)
        {
            anim.SetTrigger("petTrigger");
            return;
        }

        Debug.Log("I AM A SHEEP THAT HAS BEEN PETTED");
        cpnm.enabled = true;

        // Fire event to ALL listeners
        onInteracted?.Invoke();
    }

    void IInteractable.SetUIActive(bool b)
    {
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
