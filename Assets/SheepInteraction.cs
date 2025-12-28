using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject UIBillboard;

    void IInteractable.Interact()
    {
        Debug.Log("I AM A SHEEP THAT HAS BEEN PETTED");
    }

    void IInteractable.SetUIActive(bool b)
    {
        UIBillboard.SetActive(b);
    }
}
