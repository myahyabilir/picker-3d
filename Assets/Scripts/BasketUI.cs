using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasketUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private int minimumCountToPass;

    private void Start()
    {
        text.text = "0/" + minimumCountToPass;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }
}
