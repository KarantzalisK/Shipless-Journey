using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimations : MonoBehaviour
{
    public Animator CrewUiAnimator;
    public Animator DistanceUiAnimator;
    public Animator PauseButtonUiAnimator;
    public void CrewUiAnimationTrigger()
    {
        CrewUiAnimator.Play("CrewUiAnimationLeft");
    }

    public void DistanceMapAnimationTrigger()
    {
        DistanceUiAnimator.Play("MapDistanceComeTop");
    }

    public void PauseUiComeIfFirstTime()
    {
        PauseButtonUiAnimator.Play("PauseUiAnimation");
    }

}
