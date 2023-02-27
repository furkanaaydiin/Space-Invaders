using System.Collections;
using UnityEngine;

public class PlayerConrollers : MonoBehaviour
{
public GameObject bulletFrefeb;
private const float maxX =4f;
private const float minX =-4f;



private bool isShooting;
[SerializeField] private ObjectPo _objectPo = null;

public ShipState shipState;

private Vector2 offScreenPos = new Vector2(0, -20);
private Vector2 startPos = new Vector2(0,  -6.22f);

private float directionX;


private void Start()
{
    shipState.currentHealt = shipState.maxHealt;
    shipState.currentLifes = shipState.maxLifes;
    transform.position = startPos;
    UIManager.UpdateHealtBar(shipState.currentHealt);
    UIManager.UpdateLives(shipState.currentLifes);
}


void Update()
    {
#if  UNITY_EDITOR
        if (Input.GetKey(KeyCode.A) && transform.position.x > minX) 
        {
            transform.Translate(Vector2.left * (Time.deltaTime * shipState.shipSpeed));
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            transform.Translate(Vector2.right * (Time.deltaTime * shipState.shipSpeed));
        }

        if (Input.GetKey(KeyCode.Space)&& !isShooting)
        {
            StartCoroutine(Shoot());
        }
#endif

        directionX = Input.acceleration.x;
        if (directionX<= -0.1f && transform.position.x> minX)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * shipState.shipSpeed));
        }

        if (directionX>= 0.1f && transform.position.x> maxX)
        {
            transform.Translate(Vector3.right * (Time.deltaTime * shipState.shipSpeed));
        }
    }

public void ShotButton()
{
    if (!isShooting)
    {
        StartCoroutine(Shoot());
    }
}
 
public void AddHealth()
{
    if (shipState.currentHealt == shipState.maxHealt)
    {
        UIManager.UpdateScore(250);
    }
    else
    {
        shipState.currentHealt++;
        UIManager.UpdateHealtBar(shipState.currentHealt);
    }
}

 public void AddLife()
 {
     if (shipState.currentLifes == shipState.maxLifes)
     {
         UIManager.UpdateScore(1000);
     }
     else
     {
         shipState.currentLifes++;
         UIManager.UpdateLives(shipState.currentLifes);
     }
 }

    private IEnumerator Shoot()
    {
        isShooting = true;
        GameObject obj = _objectPo.GetPoolObjects();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(shipState.fireRate);
        isShooting = false;
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet"))
        {
            col.gameObject.SetActive(false);
            TakeDamage();
        }
    }

    private IEnumerator Respawn()
    {
        transform.position = offScreenPos;
        yield return new WaitForSeconds(2);
        shipState.currentHealt = shipState.maxHealt;
        transform.position = startPos;
        UIManager.UpdateHealtBar(shipState.currentHealt);
    }

    public void TakeDamage()
    {
        shipState.currentHealt--;
         UIManager.UpdateHealtBar(shipState.currentHealt);
        if (shipState.currentHealt <= 0)
        {
            shipState.currentLifes--;
            UIManager.UpdateLives(shipState.currentLifes);
            if (shipState.currentLifes <= 0)
            {
                Debug.Log("game over");
            }
            else
            {
                // Debug.Log("resspawn");
                StartCoroutine(Respawn());
            }
        }

       
    }
}
