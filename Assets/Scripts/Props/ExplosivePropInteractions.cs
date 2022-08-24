using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExplosivePropInteractions : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private SphereCollider _sphereCollider;
    private GameObject player;
    private Transform _transform;
    private Transform playerTransform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _sphereCollider = GetComponent<SphereCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
    }

    private void Start()
    {
        _rigidbody.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FloorMainPart"))
        {
            _meshRenderer.enabled = false;
            _sphereCollider.enabled = false;
            Invoke(nameof(DestroyGameObject), 0.2f);
            PoolController.Instance.SpawnFromPool("SpherePropGroup", transform.position, Quaternion.identity);
            Invoke(nameof(Explode), 0.01f);
        }
    }
    
    private void DestroyGameObject()
    {
        gameObject.SetActive(false);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position - Vector3.up, 1.5f);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb == null) continue;
            rb.AddExplosionForce(0.2f, transform.position - Vector3.up, 1.5f, 0f, ForceMode.Impulse);
            
        }
    }

    private void Update()
    {
        if (Vector3.Distance(_transform.position, playerTransform.position) > 30) return;
        _rigidbody.isKinematic = false;
    }
}
