using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasketBottomPartInteractions : MonoBehaviour
{
    private Transform _transform;
    private List<GameObject> propsToBeEnter ;
    private int enteredPropsCount = 0;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private int minimumCountToPass;
    
    
    private void OnEnable()
    {
        Events.onPlayerReachedStopPoint += GetListOfSpheres;
    }

    private void OnDisable()
    {
        Events.onPlayerReachedStopPoint -= GetListOfSpheres;
    }

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void GetListOfSpheres(List<GameObject> props)
    {
        propsToBeEnter = props;
        if(props.Count == 0) Events.onLevelFailed?.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prop"))
        {
            other.gameObject.tag = "Respawn";
            enteredPropsCount++;
            CheckIfAllPropsEntered();
            UpdateUI();
        }
    }
    
    private void CheckIfAllPropsEntered()
    {
        if (enteredPropsCount != propsToBeEnter.Count) return;
        StartCoroutine(EndOrContinueLevel());
    }

    private IEnumerator EndOrContinueLevel()
    {
        if (enteredPropsCount >= minimumCountToPass)
        {
            yield return new WaitForSeconds(1f);
            Events.onNecessaryNumberOfPropsEnteredToBasket?.Invoke(_transform.parent);
            Destroy(this);
        }
        else Events.onLevelFailed?.Invoke();
    }

    private void UpdateUI()
    {
        text.text = enteredPropsCount + "/" + minimumCountToPass;
    }
}
