using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAndInteraction : MonoBehaviour
{ public UIScript uiScoreScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void onTriggerEnter2D(Collider2D coli)
    {
        if (coli.gameObject.tag == "Survivor")
        {
            coli.gameObject.SetActive(false);
            uiScoreScript.SurvivorCounter();
        }
        if (coli.gameObject.tag == "Wreckage")
        {
            coli.gameObject.SetActive(false);
            uiScoreScript.WreckageCounter();

        }
        if (coli.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
        }
    }
}
