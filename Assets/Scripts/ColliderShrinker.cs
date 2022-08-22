using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColliderShrinker : MonoBehaviour
{
    private BoxCollider _boxCollider;
    private Vector3 colliderCenter;
    [SerializeField] private Vector3 miniColliderCenter;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        colliderCenter = _boxCollider.center;
    }

    private void OnEnable()
    {
        Events.onCollectorsActivated += MinimizeOrMaximizeCollider;
        
    }

    private void OnDisable()
    {
        Events.onCollectorsActivated -= MinimizeOrMaximizeCollider;
    }

    private void MinimizeOrMaximizeCollider(bool shouldMaximize)
    {
        if (!shouldMaximize)
        {
            _boxCollider.center = colliderCenter;
            return;
        }

        _boxCollider.center = miniColliderCenter;



    }
}
