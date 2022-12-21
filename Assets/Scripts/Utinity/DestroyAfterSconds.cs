using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSconds : MonoBehaviour
{
    public float seconts;
   
    void Start()
    {
        Destroy(gameObject,seconts);
    }
    
    
    
}
