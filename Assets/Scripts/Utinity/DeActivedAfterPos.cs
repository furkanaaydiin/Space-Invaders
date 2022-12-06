using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActivedAfterPos : MonoBehaviour
{
    public float bulletDeactivePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > bulletDeactivePos || transform.position.y<-bulletDeactivePos)
        {
            gameObject.SetActive(false);
        }
    }
}
