﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth: MonoBehaviour {
    #region Variables
    //HP ändrad till 1000 för test bara, kommer att ändras tillbaks.
    public static float startinghealth = 1f;
    public float currenthealth;
    bool isDead = false;
    [Header("UI stuff")]
    public Image healthBar;
    [Header("Misc")]
    public AudioManager aM;
    #endregion

    void Start()
    {
        currenthealth = startinghealth;
        healthBar = GameObject.Find("PlayerHP").GetComponent<Image>();
        aM = GetComponent<AudioManager>();
        aM = FindObjectOfType<AudioManager>();
    }

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        currenthealth -= amount;
        aM.Play("PlayerTakeDamage");
        healthBar.fillAmount = currenthealth / startinghealth;
        //Refilla HP bar vid respawn!!!!!!!!

        if (currenthealth <= 0f)
        {
            GameManager.KillPlayer(this);
            isDead = true;
        }
    }
}
