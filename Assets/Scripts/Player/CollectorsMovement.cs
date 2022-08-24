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
        Events.onPlayerReachedStopPoint += DisableCollectors;

    }
    private void OnDisable()
    {
        Events.onCollectorsActivated -= ActivateOrDeactivateCollectors;
        Events.onPlayerReachedStopPoint -= DisableCollectors;
    }

    private void DisableCollectors(List<GameObject> list)
    {
        rightOne.gameObject.SetActive(false);
        leftOne.gameObject.SetActive(false);
    }

    private void ActivateOrDeactivateCollectors(bool shouldActivate)
    {
        if (!shouldActivate)
        {
            DisableCollectors(null);
            StopCoroutine($"RotateObject");
            return;
        }
        rightOne.gameObject.SetActive(true);
        leftOne.gameObject.SetActive(true);

        
        StartCoroutine(RotateObject(rightOne, -1));
        StartCoroutine(RotateObject(leftOne, 1));

    }
    private IEnumerator RotateObject(Transform transformToBeRotated, float isNegative)
    {
        var elapsedTime = 0f;
        var timer = 15f;

        while (elapsedTime < timer)
        {
            transformToBeRotated.eulerAngles += Vector3.up * (720 * Time.deltaTime * isNegative);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
