﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Animator woodUiAnimator;
    public GameObject PlayButtonUI;
    public Animator BoardAnimator;

    private bool playButtonPressed = false;
    private bool executedOnce = false;
    private float timer=2f;

    void Awake()
    {
        Shark.gameStarted = false;
        Player.gameStarted = false;
        MovingShark.gameStarted = false;
        Barel_Behav.gameStarted = false;
        Bird_behavor.gameStarted = false;
        EndIsland.gameStarted = false;
        Rum.gameStarted = false;
        RockMovement.gameStarted = false;
    }
    
    public void StartGameButton()
    {
        PlayButtonUI.SetActive(false);
        RockMovement.gameStarted = true;
       
    }

    public void ShipWrecked()
    {
        PlayButtonUI.SetActive(false);

        //Afou stoukareis me petra kai vithistei to ploio paizeis to parakatw animation
        woodUiAnimator.Play("WoodUiAnimationLeft");
        //epeita kaloume na erthei o paiktis apo aristera me ti sanida
        BoardAnimator.Play("BoardComeLeft");

        playButtonPressed = true;
    }

    private void Update()
    {
        if (!executedOnce && playButtonPressed)
        {
            if (timer <= 0 )
            {
                Shark.gameStarted = true;
                Player.gameStarted = true;
                MovingShark.gameStarted = true;
                Barel_Behav.gameStarted = true;
                Bird_behavor.gameStarted = true;
                EndIsland.gameStarted = true;
                Rum.gameStarted = true;
                FindObjectOfType<RockMovement>().linearSpeed = -0.15f;
                FindObjectOfType<UIScript>().GetPositionsOfPlayerAndEnd();

                executedOnce = true;
            }
            else {
                timer -= Time.deltaTime;
            }
        }
    }

}
