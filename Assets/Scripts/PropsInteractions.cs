using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsInteractions : MonoBehaviour
{
    private bool stillInPlayer;
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        Events.onPlayerReachedStopPoint += GoForward;
    }

    private void OnDisable()
    {
        Events.onPlayerReachedStopPoint -= GoForward;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void GoForward(List<GameObject> listFromEvent)
    {
        if (!stillInPlayer) return;
        _rigidbody.AddForce(Vector3.forward * 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BasketBottom"))
        {
            Events.onPropReachedToBasket?.Invoke(); 
            Invoke(nameof(DestroyGameObject), 0.5f);
        }
    }
    private void DestroyGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stillInPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stillInPlayer = false;
    }
}
