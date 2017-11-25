﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Text text;
    public Image[] healthImages;
    public Sprite[] healthSprites;

    private int heartAmount = 3;
    private int currentHealth;
    public int healthPerHeart = 2;

    public GameObject gameOverScreen;
    PlayerControllerMapTut player;


    void Awake()
    {
        text = GetComponent<Text>();
        gameOverScreen.SetActive(false);
    }
    // Use this for initialization
    void Start()
    {
        // take player health here instead
        checkHeartAmount();
        player = FindObjectOfType<PlayerControllerMapTut>();
        currentHealth = player.health;
        heartAmount = currentHealth;
    }

    private void Update()
    {
        currentHealth = player.health;
        UpdateHearts();

        if (player.health <= 0) gameOverScreen.SetActive(true);

    }

    void checkHeartAmount()
    {
        for (int i = 0; i < heartAmount; i++)
        {
            healthImages[i].enabled = true;
        }
    }

    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else
            {
                i++;
                if (currentHealth >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }

    }
}
