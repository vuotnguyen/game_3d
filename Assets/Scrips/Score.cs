﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public death_menu death_Menu;
    private float score = 0.0f;

    private int dificulLevel = 1;
    private int maxDificulLevel = 10;
    private int scoreToNextLevel = 10;
    public Text scoreText;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){
            return;
        }
        if(score >= scoreToNextLevel)
            LevelUp();
            score +=Time.deltaTime * dificulLevel;
            scoreText.text = "score: " + ((int)score).ToString();
        
    }
    private void LevelUp(){
        if(dificulLevel == maxDificulLevel)
            return;
        
        scoreToNextLevel *=2;
        dificulLevel ++;
        GetComponent<player_moto>().SetSpeed(dificulLevel);
        Debug.Log(dificulLevel);

    }
    private bool isDead = false;
    public void OnDeath(){
        isDead = true;
        death_Menu.toggleMenu(score);
    }
}
