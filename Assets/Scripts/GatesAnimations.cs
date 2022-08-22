using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesAnimations : MonoBehaviour
{
    private Animator[] _animators;

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
        foreach (var animator in _animators)
        {
            animator.Play("OpenUp");
        }
    }
}
