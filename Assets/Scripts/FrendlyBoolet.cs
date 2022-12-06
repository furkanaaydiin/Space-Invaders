using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FrendlyBoolet : MonoBehaviour
{
  public float speed = 10;

  private void Update()
  {
    transform.Translate(Vector2.up * (Time.deltaTime * speed));
  }

  private void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.CompareTag("Alien"))
    {
      col.gameObject.GetComponent<Alien>().Kill();
      gameObject.SetActive(false);
    }

    if (col.gameObject.CompareTag("EnemyBullet"))
    {
      col.gameObject.SetActive(false);
      gameObject.SetActive(false);
            
    }
  }
}
