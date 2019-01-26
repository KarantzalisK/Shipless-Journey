﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript: MonoBehaviour
{
    float progressValue;
    public GameObject player,destination;
    public Slider progressSlider;
    public string wreckageScore,survivorScore;
    public Text wreckageUI, survivorUi;
    public int survivors = 0, wreckageNum=0;
    // Start is called before the first frame update
    void Start()
    {
        progressSlider.minValue = player.transform.position.x;
        progressSlider.maxValue = destination.transform.position.x;
        progressValue = (destination.transform.position.x);


    }

    // Update is called once per frame
    void Update()
    {
        progressSlider.value =progressValue-destination.transform.position.x;
        wreckageUI.text = wreckageScore;
        survivorUi.text = survivorScore;
    }
    public void SurvivorCounter()
    {
        survivors++;

        survivorScore = (survivors.ToString());
    }
    public void WreckageCounter()
    {
        wreckageNum++;
        wreckageScore = (wreckageNum.ToString());

    }


}
