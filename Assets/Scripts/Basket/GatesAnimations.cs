using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesAnimations : MonoBehaviour
{
    private Animator[] _animators;
    public bool collidingWithPlayer;

    private void OnEnable()
    {
        Events.onPlayerMovementContinue += OpenGates;
    }

    private void OnDisable()
    {
        Events.onPlayerMovementContinue -= OpenGates;
    }

    private void Awake()
    {
        _animators = GetComponentsInChildren<Animator>();
    }

    private void OpenGates()
    {
        if (!collidingWithPlayer) return;
        foreach (var animator in _animators)
        {
            animator.Play("OpenUp");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collidingWithPlayer = true;
        }
    }
}
