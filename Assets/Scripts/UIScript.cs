using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript: MonoBehaviour
{
    float progressValue;
    public GameObject player,destination;
    public Slider progressSlider;
    // Start is called before the first frame update
    void Start()
    {
        progressSlider.minValue = player.transform.position.x;
        progressSlider.maxValue = destination.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        progressValue = (player.transform.position.x);
        progressSlider.value = progressValue;

    }

   
}
