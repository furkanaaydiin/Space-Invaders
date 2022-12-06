using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSconds : MonoBehaviour
{
    public float seconts;
   
    void Start()
    {
       // Destroy(gameObject,seconts);
    }

    
    void Update()
    {
        if (transform.position.y > 7f)
        {
            gameObject.SetActive(false);
        }
    }
}
