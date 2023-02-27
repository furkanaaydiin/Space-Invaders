using UnityEngine;

public class DestroyAfterSconds : MonoBehaviour
{
    public float seconts;
   
    void Start()
    {
        Destroy(gameObject,seconts);
    }
    
    
    
}
