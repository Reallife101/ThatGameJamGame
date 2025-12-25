using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepInteraction : MonoBehaviour, IInteractable
{
    void IInteractable.Interact()
    {
        Debug.Log("I AM A SHEEP THAT HAS BEEN PETTED");
    }

}
