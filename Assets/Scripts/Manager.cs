using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    private GameObject[] Enemies;

    public void findEnemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void endGame()
    {
        //stop enemies
        for (int x = 0; x < Enemies.Length; x++)
        {
            Enemies[x].GetComponent<EnemyMovement>().HorizontalSpeed = 0;
            Enemies[x].GetComponent<Animator>().speed = 0;
        }

        //stop player
        GameObject.FindGameObjectWithTag("Player").GetComponent<movementPlayer>().KillPlayer();

        //change UI
        GameObject.Find("UI").GetComponent<manageUI>().SetGameOver();

    }

    



}
