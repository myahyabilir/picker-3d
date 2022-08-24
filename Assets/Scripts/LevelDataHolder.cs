using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHolder : MonoBehaviour
{
    [SerializeField] private Transform propsTransform;
    
    public Level levelScriptableObject;
    private List<LevelValues.LevelObjects> propObjects;
    private void Start()
    {
        propObjects = new List<LevelValues.LevelObjects>();
        
        //Bu kısım normalde olmayacak

        foreach (Transform child in propsTransform)
        {
            LevelValues.LevelObjects newLevelObject = new LevelValues.LevelObjects();
            newLevelObject.levelObject = child.gameObject;
            newLevelObject.objectPosition = child.transform.position;
            
            propObjects.Add(newLevelObject);
            Destroy(child.gameObject);
        }
        /******/
        
        
        //Buradaki döngü bitmiş projede level objelerini pooldan çağıracak.
        foreach (LevelValues.LevelObjects obj in propObjects)
        {
            GameObject pooledObject =
                PoolController.Instance.SpawnFromPool(obj.levelObject.tag, Vector3.zero, Quaternion.identity);
            
            pooledObject.transform.parent = propsTransform;
            pooledObject.transform.position = obj.objectPosition;
        }
    }
}
