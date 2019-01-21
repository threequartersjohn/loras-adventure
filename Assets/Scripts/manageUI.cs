﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class manageUI : MonoBehaviour {

    [SerializeField]
    private Text text;

    [SerializeField]
    private GameObject player;
    private movementPlayer movementPlayer;
    private bool GameOver = false;

	// Use this for initialization
	void Start () {
        movementPlayer = player.GetComponent<movementPlayer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameOver)
        {


        }

        else
        {
            ManageDebugText();
        }

        

    }

    public void SetGameOver()
    {
        GameOver = true;

        text.text = "";
    }

    void ManageDebugText()
    {
        string DebugText = "Points: " + movementPlayer.points + "\n";

        DebugText += "Time to Change: " + ((Mathf.Round((movementPlayer.TimeToChangeGravity - Time.time) * 100f) / 100f)).ToString() + "\n";
        
        if (player.GetComponent<Rigidbody2D>().gravityScale < 0)
        {
            DebugText += "Pulling UP\n";
        }

        else
        {
            DebugText += "Pulling DOWN\n";
        }
        

        text.text = DebugText;
    }
}
