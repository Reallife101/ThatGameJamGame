using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class MultiEventWallListener : MonoBehaviour
{
    [Header("Num Events To Listen To")]
    [SerializeField] private int numEvents;

    [Header("Wall")]
    [SerializeField] GameObject wall;

    private int currentNumEvents = 0;

    public void RegisterEvent()
    {
        currentNumEvents++;

        if (currentNumEvents>=numEvents)
        {
            wall.SetActive(false);
        }
    }
}
