using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private List<GameObject> props;
    private bool removalFromListEnabled = true;

    private void OnEnable()
    {
        Events.onPlayerMovementContinue += ResetList;
    }

    private void OnDisable()
    {
        Events.onPlayerMovementContinue -= ResetList;
    }

    private void Awake()
    {
        props = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StopPoint"))
        {
            removalFromListEnabled = false;
            Events.onPlayerReachedStopPoint?.Invoke(props);
        }
        
        if (other.gameObject.CompareTag("Prop"))
        {
            props.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("CollectorActivator"))
        {
            Events.onCollectorsActivated?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Prop"))
        {
            if (!removalFromListEnabled) return;
            props.Remove(other.gameObject);
        }
    }

    private void ResetList()
    {
        removalFromListEnabled = true;
        props = new List<GameObject>();
    }
}
