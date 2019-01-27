using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript: MonoBehaviour
{
    float progressValue;
    public GameObject player,destination;
    public Slider progressSlider;
    public string wreckageScore,rumScore;
    public Text wreckageUI, rumUI;
    public int rumNUM = 0, wreckageNum=0;
    private bool GameStarted = false;
    // Start is called before the first frame update
    public void GetPositionsOfPlayerAndEnd()
    {
        progressSlider.minValue = player.transform.position.x;
        progressSlider.maxValue = destination.transform.position.x;
        progressValue = (destination.transform.position.x);
        wreckageUI.text = wreckageScore;
        rumUI.text = rumScore;
        progressSlider.value = 0;
        GameStarted = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameStarted)
        {
            progressSlider.value = progressSlider.minValue + Mathf.Abs(progressValue - destination.transform.position.x);
            wreckageUI.text = wreckageScore;
            rumUI.text = rumScore;
        }
    }
    //public void SurvivorCounter()
    //{
    //    survivors++;

    //    survivorScore = (survivors.ToString());
    //}
    public void WreckageCounter()
    {
        wreckageNum++;
        wreckageScore = (wreckageNum.ToString());

    }
    public void rumCounter()
    {
        rumNUM++;
        rumScore = rumNUM.ToString();
    }


}

