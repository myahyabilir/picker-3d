using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isMovementEnabled = false;
    private Vector2 pointerPosition;
    private InputController _inputController;
    [SerializeField] private float verticalSpeed = 5f;
    [SerializeField] private float horizontalSpeed = 2f;
    private Rigidbody _rigidbody;
    private Transform _transform;
    private float horizontalMovement;
    [SerializeField] private float maximumHorizontalMovement = 3f;
    

    private Coroutine velocityResetCoroutine;
    private float roadsHorizontalMargin;
    
    
    private void OnEnable()
    {
        Events.onLevelStarted += ActivateMovement;
        Events.onPlayerMovementContinue += ActivateMovement;
        Events.onPlayerReachedStopPoint += DeactivateMovement;
        
    }

    private void OnDisable()
    {
        Events.onLevelStarted -= ActivateMovement;
        Events.onPlayerMovementContinue -= ActivateMovement;
        Events.onPlayerReachedStopPoint -= DeactivateMovement;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputController = new InputController();
        _inputController.Enable();
        _transform = transform;
    }

    private void ActivateMovement()
    {
        isMovementEnabled = true;
    }

    private void DeactivateMovement(List<GameObject> listFromEvent)
    {
        isMovementEnabled = false;
    }

    private void FixedUpdate()
    {
        if (!isMovementEnabled)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }

        pointerPosition = _inputController.PlayerMovement.PointerDeltaPosition.ReadValue<Vector2>();
        var xPos = _transform.position.x;
        if (Mathf.Abs(xPos) > maximumHorizontalMovement)
        {
            if (Mathf.Abs(xPos) > maximumHorizontalMovement + 0.2f) 
            {
                var xPosOptimizor = Mathf.Clamp(xPos, -maximumHorizontalMovement, maximumHorizontalMovement);
                var position = _rigidbody.position;
                position = new Vector3(xPosOptimizor, position.y, position.z);
                _rigidbody.position = position;
            }
            
            if (xPos < maximumHorizontalMovement)
            {
                if (pointerPosition.x < 0) pointerPosition.x = 0;
            }
            else if (xPos > maximumHorizontalMovement)
            {
                if (pointerPosition.x > 0) pointerPosition.x = 0;
            }
        }
        _rigidbody.velocity = new Vector3(pointerPosition.x * horizontalSpeed, 0, 1 * verticalSpeed);
    }
    

    private IEnumerator MakeVelocityZeroOverTime(float making_zero_interval)
    {
        Vector3 velocityToBeEffected = _rigidbody.velocity;
        Vector3 desiredVelocity = Vector3.zero;
        var timer = making_zero_interval;
        float progress;
        var passedTime = 0f;

        while (passedTime < timer)
        {
            progress = passedTime / timer;
            _rigidbody.velocity = Vector3.Lerp(velocityToBeEffected, desiredVelocity, progress);
            passedTime += Time.deltaTime;
            yield return null;
        }

        velocityResetCoroutine = null;
    }
}
