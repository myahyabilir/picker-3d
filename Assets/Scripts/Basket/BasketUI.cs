using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasketUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [HideInInspector] public int minimumCountToPass;
    private Level levelWeIn;
    [SerializeField] private int basketNumber;

    private void Awake()
    {
        levelWeIn = GetComponentInParent<LevelDataHolder>().levelScriptableObject;

        switch (basketNumber)
        {
            case 1:
                minimumCountToPass = levelWeIn.level.firstBasketCount;
                break;
            case 2:
                minimumCountToPass = levelWeIn.level.secondBasketCount;
                break;
            case 3:
                minimumCountToPass = levelWeIn.level.thirdBasketCount;
                break;
            default:
                minimumCountToPass = 10;
                break;
        }
    }

    private void Start()
    {
        
        text.text = "0/" + minimumCountToPass;
    }

}
