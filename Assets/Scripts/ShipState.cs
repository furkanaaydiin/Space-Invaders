using UnityEngine;


[System.Serializable]
public class ShipState
{
   [Range(1, 5)] public int maxHealt;

   [HideInInspector] public int currentHealt;
   [HideInInspector] public int maxLifes = 3;
   [HideInInspector] public int currentLifes = 3;
   public float shipSpeed;
   public float fireRate;
   
}
