using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Events
{
    public static Action onLevelStarted;
    public static Action<List<GameObject>> onPlayerReachedStopPoint;
    public static Action onLevelFailed;
    public static Action onPropReachedToBasket;
    public static Action<Transform> onNecessaryNumberOfPropsEnteredToBasket;
    public static Action onPlayerMovementContinue;
    
    public static Action onProceedToNextLevel;
    public static Action onLevelFinished;
    public static Action<bool> onCollectorsActivated;
}
