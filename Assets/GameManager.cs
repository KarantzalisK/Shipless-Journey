using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject loseText;
    
    //Method in which you can have life and counting other Stuff
    public void PlayerGotHit() {

        Lose();
    }

    //show lose menu etc...
    private void Lose() {
        loseText.SetActive(true);
    }

}
