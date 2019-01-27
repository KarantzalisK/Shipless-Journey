using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreAndInteraction : MonoBehaviour

{
    public GameObject LosePanel;
    public GameObject PausePanel;
    public GameObject EndPanel;
    public Button PauseButtonUi;
    public UIScript uiScoreScript;

    public void PauseButton()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void ResumeButton()
    {
        
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        PauseButtonUi.interactable = true;
    }
 
    private void OnTriggerEnter2D(Collider2D coli)
    {
        Debug.Log("DOULEPSE");
        //if (coli.gameObject.tag == "Survivor")
        //{
        //    coli.gameObject.SetActive(false);
        //    uiScoreScript.SurvivorCounter();
        //}
        if (coli.gameObject.tag == "Wreckage")
        {
            coli.gameObject.SetActive(false);
            uiScoreScript.WreckageCounter();

        }if (coli.gameObject.tag == "Rum")
        {
            coli.gameObject.SetActive(false);
            uiScoreScript.rumCounter();

        }
        if (coli.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0.0f;
            LosePanel.SetActive(true);
            PauseButtonUi.interactable = false;
        }

        if (coli.gameObject.tag == "End")
        {
            Time.timeScale = 0.0f;
            EndPanel.SetActive(true);
            PauseButtonUi.interactable = false;
        }
    }
}
