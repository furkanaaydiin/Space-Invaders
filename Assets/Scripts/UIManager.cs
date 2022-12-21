using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;


    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI HightscoreText;
    private int hightscore;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI waveText;
    private int wave;
    public Image[] LifeSprites;
    public Image healthBar;
    public Sprite[] healthBars;
    private Color32 active = new Color(1, 1, 1, 1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);
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

    public static void UpdateLives(int I)
    {
        foreach (Image i in instance.LifeSprites)
        {
            i.color = instance.inactive;
        }

        for (int i = 0; i < I; i++)
        {
            instance.LifeSprites[i].color = instance.active;
        }
    }
    public static void UpdateHealtBar(int h)
    {
        instance.healthBar.sprite = instance.healthBars[h];
    }

    public static void UpdateScore(int s)
    {
        instance.score += s;
        instance.scoreText.text = instance.score.ToString("000,000");
    }

    public static void UpdateHighScore()
    {
        
    }

    public static void UpdateWave()
    {
        instance.wave++;
        instance.waveText.text = instance.wave.ToString();
    }

    public static void UpdateCoins()
    {
        instance.coinText.text = Inventory.CurrentCoins.ToString();
    }
}
