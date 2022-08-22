using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CollectorsMovement : MonoBehaviour
{
    [SerializeField] private Transform rightOne;
    [SerializeField] private Transform leftOne;
    
    private void OnEnable()
    {
        Events.onCollectorsActivated += ActivateOrDeactivateCollectors;
        
    }

    private void OnDisable()
    {
        Events.onCollectorsActivated -= ActivateOrDeactivateCollectors;
    }

    private void ActivateOrDeactivateCollectors(bool shouldActivate)
    {
        if (!shouldActivate)
        {
            rightOne.gameObject.SetActive(false);
            leftOne.gameObject.SetActive(false);
            return;
        }
        rightOne.gameObject.SetActive(true);
        leftOne.gameObject.SetActive(true);

        rightOne.DORotate(new Vector3(0, 180, 0), 0.5f).SetLoops(-1);
        leftOne.DORotate(new Vector3(0, 180, 0), 0.5f).SetLoops(-1);

        StartCoroutine(DeactivateCollectors());
    }

    private IEnumerator DeactivateCollectors()
    {
        yield return new WaitForSeconds(3f);
        Events.onCollectorsActivated?.Invoke(false);
    }
}
