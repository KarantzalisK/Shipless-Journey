using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloat : MonoBehaviour
{
    public float linearSpeed = 0f;
    public float animationTime = 2f;
    public float jumpHeightDiv = 8;

    private float startY;

    public static bool gameStarted = false;
    private bool canStartAnimation = true;

    public AnimationCurve animationCurve;
    private bool coroutineswitch = false;

    // Start is called before the first frame update
    void Start()
    {
        startY = gameObject.transform.position.y;
    }







    // Update is called once per frame
    void Update()
    {
        if (gameStarted) transform.Translate(linearSpeed, 0, 0);
        if (canStartAnimation && !coroutineswitch) StartAnimation();
        if (canStartAnimation && coroutineswitch) StartAnimationInverted();
    }





    void StartAnimation()
    {
        canStartAnimation = false;
        StartCoroutine(AnimateHeight(animationCurve, animationTime));
    }
    void StartAnimationInverted()
    {
        canStartAnimation = false;
        StartCoroutine(InvertedAnimateHeight(animationCurve, animationTime));
    }

    IEnumerator AnimateHeight(AnimationCurve Curve, float totalTime)
    {
        float timer = 0;
        while (timer <= totalTime)
        {
            transform.Translate(linearSpeed, 1 * (Curve.Evaluate(timer / totalTime) / jumpHeightDiv), 0, Space.World);
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }

        transform.position = new Vector2(transform.position.x, startY);
        canStartAnimation = true;
        coroutineswitch = true;
    }
    IEnumerator InvertedAnimateHeight(AnimationCurve Curve, float totalTime)
    {
        float timer = totalTime;
        while (timer >= 0)
        {
            transform.Translate(linearSpeed, 1 * (Curve.Evaluate(timer / totalTime) / jumpHeightDiv), 0, Space.World);
            timer -= Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }
        transform.position = new Vector2(transform.position.x, startY);
        canStartAnimation = true;
        coroutineswitch = false;
    }


}
