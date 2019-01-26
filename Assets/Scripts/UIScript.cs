using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript: MonoBehaviour
{
    float progressValue,score;
    public GameObject player,destination;
    public Slider progressSlider;
    public Text showScore;
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
    private void OnTriggerEnter2D(Collider2D coli)
    { if (coli.gameObject.tag == "Enemy")
        {
            coli.gameObject.SetActive(false);
            score++;
            showScore.text = "Score:" + score.ToString();

        }
        
    }
}
