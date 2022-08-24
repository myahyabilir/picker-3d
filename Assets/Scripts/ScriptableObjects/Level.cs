using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class LevelValues
{
    public int levelNo;
    public int firstBasketCount;
    public int secondBasketCount;
    public int thirdBasketCount;
    public List<LevelObjects> levelObjects;

    [Serializable]
    public struct LevelObjects
    {
        public GameObject levelObject;
        public Vector3 objectPosition;
        
    }
}

[CreateAssetMenu(fileName = "Level", menuName = "LevelObject", order = 1)]
public class Level : ScriptableObject
{
    public LevelValues level;
    
}
