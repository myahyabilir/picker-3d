﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        QualitySettings.vSyncCount = 0; 
        Application.targetFrameRate = 60;
    }
}
