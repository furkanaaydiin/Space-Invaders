using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] allAlienSets;
    private GameObject currentSet;
    private Vector2 spawnPos = new Vector2(0, 10);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnNewWave();
    }

    public static void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        if (currentSet != null)
        {
            Destroy(currentSet);
        }

        yield return new WaitForSeconds(3f);
        currentSet = Instantiate(allAlienSets[Random.Range(0, allAlienSets.Length)], spawnPos, Quaternion.identity);
        UIManager.UpdateWave();
    }
}
