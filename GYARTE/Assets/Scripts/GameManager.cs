﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {
    #region Variables
    public static GameManager instance = null;
    public Transform player;
    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay;
    private static int remainingLives = 3;
    #endregion

    void Start () 
   {
        if(instance == null)
        {
            instance = this;
        }
          else if(instance != this)
          {
            Destroy(gameObject);
          }
   }
	
    void Update()
    {
        if (player == null)
            return;
    }

    public static int RemainingLives
    {
        get { return remainingLives; }
    }

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds (spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer(PlayerHealth player)
    {
        Destroy(player.gameObject);
        Debug.Log("Dead, respawning soon!");
        remainingLives--;
        Debug.Log(remainingLives);
        if(remainingLives <= 0)
        {
            instance.EndGame();
        }
        else
        {
            instance.StartCoroutine(instance.RespawnPlayer());
        }
    }

    public void EndGame()
    {
        Debug.Log("Game Over!");
    }
}