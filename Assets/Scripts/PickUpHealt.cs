using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealt : Pickup
{
    public override void PickMeUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConrollers>().AddHealth();
        gameObject.SetActive(false);
    }
}
