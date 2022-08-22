using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    private Transform _transform;
    private List<GameObject> propsToBeEnter;
    [SerializeField] private GameObject stopPoint;
    private BoxCollider[] _boxColliders;
    private Material _material;
    [SerializeField] private Material floorMaterial;
    
    private void OnEnable()
    {
        Events.onNecessaryNumberOfPropsEnteredToBasket += MoveUpwards;
    }

    private void OnDisable()
    {
        Events.onNecessaryNumberOfPropsEnteredToBasket -= MoveUpwards;
    }

    private void Awake()
    {
        _transform = transform;
        _boxColliders = GetComponents<BoxCollider>();
        _material = GetComponent<MeshRenderer>().material;
    }
    
    private void MoveUpwards(Transform basket)
    {
        if (basket != _transform) return;
        var position = _transform.position;
        _transform.DOMove(new Vector3(position.x, -0.5f, position.z), 1f).OnComplete(() =>
        {
            stopPoint.tag = "StopPointRemoved";
            foreach (var boxCollider in _boxColliders)
            {
                boxCollider.enabled = false;
            }
            Events.onPlayerMovementContinue?.Invoke();
        });
        _material.DOColor(floorMaterial.color, 1f);
    }
}
