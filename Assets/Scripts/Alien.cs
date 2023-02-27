using UnityEngine;
using Random = UnityEngine.Random;

public class Alien : MonoBehaviour
{
    public int scoreValue;
    public GameObject explosion;
    public GameObject coinPrefab;
    public GameObject lifePrefab;
    public GameObject healthPrefab;
    private const int Life_Chance = 1;
    private const int Healt_Chance = 10;
    private const int Coin_Chance = 50;
    


    public void Kill()
    {
        UIManager.UpdateScore(scoreValue);
        ElienMaster.allAlien.Remove(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);

        int ran = Random.Range(0, 1000);

        if (ran <= Life_Chance)
        {
            Instantiate(lifePrefab, transform.position, Quaternion.identity);
        }
        else if (ran <= Healt_Chance)
        {
            Instantiate(lifePrefab, transform.position, Quaternion.identity);
        }
        else if (ran <=  Coin_Chance)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        if (ElienMaster.allAlien.Count == 0)
        {
            GameManager.SpawnNewWave();
        }
        gameObject.SetActive(false);
    }
    
        
    
}
