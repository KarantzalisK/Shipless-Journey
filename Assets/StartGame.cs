using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Animator woodUiAnimator;
    public GameObject PlayButtonUI;
    public Animator BoardAnimator;
    public void StartGameButton()
    {
        PlayButtonUI.SetActive(false);

        //Afou stoukareis me petra kai vithistei to ploio paizeis to parakatw animation
        woodUiAnimator.Play("WoodUiAnimationLeft");
        //epeita kaloume na erthei o paiktis apo aristera me ti sanida
        BoardAnimator.Play("BoardComeLeft");
    }
}
