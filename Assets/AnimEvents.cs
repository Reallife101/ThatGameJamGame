using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
    private playerController pController;

    private void Start()
    {
        pController = GetComponentInParent<playerController>();
    }
    public void EnableMovement()
    {
        pController.EnableMovement();
    }
}
