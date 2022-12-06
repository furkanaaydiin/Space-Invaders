using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ObjectPo : MonoBehaviour
{
    private Queue <GameObject> poolObjects;
    [SerializeField] private GameObject objectPrefeb;
    [SerializeField] private int poolSize;

    private void Awake()
    {
        poolObjects = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefeb);
            obj.SetActive(false);
            poolObjects.Enqueue(obj);
        }
    }

    public GameObject GetPoolObjects()

    {
        GameObject obj = poolObjects.Dequeue();
        obj.SetActive(true);
        poolObjects.Enqueue(obj);
        return obj;
    }

   
}
