using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElienMaster : MonoBehaviour
{
    [SerializeField] private ObjectPo _objectPo;
    public GameObject bullerPrefeb;

    private Vector3 hMoveDistance = new Vector3(0.05f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 0.15f, 0);

  
    private const float MİN_LEFT = -4f;
    
    private const float MAX_RIGHT = 4f;

    public static List<GameObject> allAlien = new List<GameObject>();

    private bool movingRinght;
    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;

    private float shootTimer = 3f;
    private const float ShotTime = 3f;

    private const float Max_Move_Speed = 0.02f; 

    public GameObject motherShipPrefeb;
    private Vector3 motherShipSpawnPos = new Vector3(3.72f, 3.45f, 0);
    private float motherShipTimer = 2f;
    private const float MOTHERSHIP_MIN = 15f;
    private const float MOTHERSHIP_MAX = 15f;
    private const float START_Y = 1.7F;
    private bool ENTERİNG = true;
    
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien")) 
        {
            allAlien.Add(go);
        }
    }

    
    void Update()
    {
        // bakılacakkkkkk
        if (ENTERİNG)
        {
            transform.Translate(Vector2.down * Time.deltaTime*10 );
            
            if (transform.position.y <= START_Y)
            {
                ENTERİNG = false;
            }
        }
        else
        {
            if (moveTimer <= 0)
            {
                MoveEnemies();
            }

            if (shootTimer <=0)
            {
                Shot();
            }
        
            if (motherShipTimer <= 0)
            {
                SpawnMotherShip();
            }
            moveTimer -= Time.deltaTime;
            shootTimer -= Time.deltaTime;
            motherShipTimer -= Time.deltaTime;
        }
        
    }

    public void MoveEnemies()
    {
        if (allAlien.Count > 0)
        {
            int hitMax = 0;
            for (int i = 0; i < allAlien.Count; i++)
            {
                if (movingRinght)
                {
                    allAlien[i].transform.position += hMoveDistance;
                }
                else
                {
                    allAlien[i].transform.position -= hMoveDistance;
                }

                if (allAlien[i].transform.position.x > MAX_RIGHT || allAlien[i].transform.position.x < MİN_LEFT)
                {
                    hitMax++;
                }
                
            }

            if (hitMax > 0)
            {
                for (int i = 0; i < allAlien.Count; i++)
                {
                    allAlien[i].transform.position -= vMoveDistance;
                }

                movingRinght = !movingRinght;

            }
        }

        moveTimer = GetMoveSpeed();

    }

    private void SpawnMotherShip()
    {
        Instantiate(motherShipPrefeb, motherShipSpawnPos, quaternion.identity);
        motherShipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);
    }

    private void Shot()
    {
        Vector2 pos = allAlien[Random.Range(0, allAlien.Count)].transform.position;
        GameObject obj = _objectPo.GetPoolObjects();
        obj.transform.position = pos;
        shootTimer = ShotTime;
    }

    private float GetMoveSpeed()
    {
        float f = allAlien.Count * moveTime;

        if (f < Max_Move_Speed)
        {
            return Max_Move_Speed;
        }
        else
        {
            return f;
        }
            
        

        
    }
}
