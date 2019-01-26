using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript: MonoBehaviour
{
    float progressValue;
    public GameObject player,destination;
    public Slider progressSlider;
    public Text showScore;
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

    }
    public void SurvivorCounter()
    {
        survivors++;

    }
    public void WreckageCounter()
    {
        wreckageNum++;
    }
    

    }

