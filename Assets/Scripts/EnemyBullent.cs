using UnityEngine;

public class EnemyBullent : MonoBehaviour
{
    public float speed = 10;
    void Update()
    {
        transform.Translate(Vector2.down * (Time.deltaTime * speed));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
    }
}
