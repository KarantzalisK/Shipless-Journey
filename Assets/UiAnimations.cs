using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimations : MonoBehaviour
{
    public Animator CrewUiAnimator;
    public Animator DistanceUiAnimator;
    public void CrewUiAnimationTrigger()
    {
        CrewUiAnimator.Play("CrewUiAnimationLeft");
    }

    public void DistanceMapAnimationTrigger()
    {
        DistanceUiAnimator.Play("MapDistanceComeTop");
    }


}
