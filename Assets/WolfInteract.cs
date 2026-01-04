using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WolfInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject UIBillboard;

    [Header("Events")]
    [SerializeField] private UnityEvent onInteracted;

    [SerializeField] private GameObject healVFX;

    bool inRange;

    private Animator anim;

    private void Start()
    {

        inRange = false;
        anim = GetComponentInChildren<Animator>();
    }

    void IInteractable.Interact()
    {
        if(inRange)
        {
            Debug.Log("BEANS");
            return;
        }

        Debug.Log("I AM A SHEEP THAT HAS BEEN PETTED");
        inRange = true;

        // Fire event to ALL listeners
        onInteracted?.Invoke();
    }

    void IInteractable.SetUIActive(bool b)
    {
        if (!inRange)
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
        
    }
    
}
