using UnityEngine;

public class Sheld : MonoBehaviour
{

    public Sprite[] states;
    private int healt;
    private SpriteRenderer sr;
    
    void Start()
    {
        healt = 4;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet") || col.gameObject.CompareTag("FrendlyBullet"))
        {
            col.gameObject.SetActive(false);
            healt--;
            if (healt<=0)
            {
                Destroy(gameObject);
            }
            else
            {
                sr.sprite = states[healt - 1];
            }
        }
    }
}
