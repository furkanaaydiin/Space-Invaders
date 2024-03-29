using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public int scoreValue;
    private const float MAX_LEFT = -5;
    private float speed = 5;
    void Update()
    {
        transform.Translate(Vector2.left * (Time.deltaTime * speed));

        if (transform.position.x<= MAX_LEFT)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("FrendlyBullet"))
        {
            UIManager.UpdateScore(scoreValue);
            col.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
