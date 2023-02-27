using UnityEngine;

public class PickUpLife : Pickup
{
    public override void PickMeUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConrollers>().AddLife();
        gameObject.SetActive(false);
        
    }
}
