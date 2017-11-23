﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    // PROPOSAL(take it or leave it) since the game is mostly played by colecting and using ammo, no reload or clip size is needed! 
    // Instead the player simply has every bullet available dirrectly, let's reduce the starting ammount and have the player collect amunition.
    // as stated this is a proposal, please come with suggestions on why this would be a stupid idea!(this would also reduce the visual need immensly so there would be less
    // text to place on screen and less code to deal with!)

    [HideInInspector]
    public GunController gun;

    public int ammo;
    public int maxAmmo;
    public int remainderAmmo;
    public int setAmmo;
    public int setMaxAmmo;
    public bool ammoEmpty = false;
    
    Text ammoText;

    void Start()
    {
        gun = FindObjectOfType<PlayerControllerMapTut>().gun;
        ammoText = GetComponent<Text>();
        ammo = setAmmo;
        maxAmmo = setMaxAmmo;
        ammoEmpty = false;
        ammoText.text = ammo + "   " + maxAmmo;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (gun == null) return;
        ammo = gun.bullets;
        Debug.Log(ammo);
        maxAmmo = gun.remForBullet;


        if (ammo <= 10)
        {
            //ammo--;
            ammoText.text = " " + ammo + "    " + maxAmmo;
        }
        else
        {
            //ammo--;
            ammoText.text = ammo + "   " + maxAmmo;
        }

        //If reloading when ammo is empty
        if (ammo == 0 && maxAmmo > 0)
        {
            ammoEmpty = true;
            if (Input.GetKeyDown("r"))
            {
               
                if (setAmmo >= maxAmmo)
                {
                    ammo = maxAmmo;
                    maxAmmo = 0;
                    ammoText.text = ammo + "    " + maxAmmo;
                }
                else
                {
                    remainderAmmo = setAmmo - ammo;
                    ammo = setAmmo;
                    maxAmmo -= setAmmo;
                    ammoText.text = ammo + "   " + maxAmmo;
                }
                ammoEmpty = false;
            }

        }

        //If reloading with ammo left
        if (ammo > 0 && ammo != setAmmo && maxAmmo > 0 && !ammoEmpty)
        {

            if (Input.GetKeyDown("r"))
            {
                //Remainder ammo is the amount of ammo needed to be reloaded
                remainderAmmo = setAmmo - ammo;
                ammoEmpty = false;

                //Normal reload
                if (maxAmmo >= setAmmo)
                {
                    maxAmmo -= remainderAmmo;
                    ammo = setAmmo;
                    ammoText.text = ammo + "   " + maxAmmo;
                }
                
                //If maxAmmo is less than the maximum amount in the magazine, but larger than the remainder
                else if (maxAmmo < setAmmo && remainderAmmo <= maxAmmo)
                {
                    ammo = setAmmo;
                    maxAmmo -= remainderAmmo;
                    ammoText.text = ammo + "   " + maxAmmo;
                }

                //If remainder is larger than maxAmmo, the rest of the ammo is reloaded int the magazine
                else if (maxAmmo < setAmmo && remainderAmmo > maxAmmo)
                {
                    ammo += maxAmmo;
                    maxAmmo = 0;
                    ammoText.text = ammo + "   " + maxAmmo;
                }
            }
        }

        if (maxAmmo <= 0 && ammo <= 0)
        {
            ammoEmpty = true;
        }

    }

}
