using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_behavor : MonoBehaviour
{
    public float linearSpeed = -0.35f;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("hit Hard");
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitBarrel);
            GameObject.Find("ScriptManager").GetComponent<GameManager>().PlayerGotHit();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStarted && canStartAnimation && !coroutineswitch) StartAnimation();
        if (gameStarted && canStartAnimation && coroutineswitch) StartAnimationInverted();
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
