using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private bool animationIsplaying = false;
    public Collider2D playerBody;
    public Collider2D playerBodyDucked;
    public Animator CharAnimator;
    public float linearSpeed = 0f;
    public float animationTime = 0.5f;
    public float jumpHeightDiv = 2;
    public float rotationMult = 5;
    public float jumpLengthDiv = 2;
    public float mult = 1F;
    public AnimationCurve heightCurve;
    public AnimationCurve RotationCurve;
    public AnimationCurve lengthCurve;
    private float startY;
    private float startX;

    private bool lengthCoroutineIsRunning = false;
    private bool coroutineswitch = false;
    private bool rotateCouroutineFinished = false;


    public static bool gameStarted = false;

    private float Speed;
    public Swipe swipeControls;
    private GameObject player;
    private Vector3 desiredPosition;
    private bool DotheJob = false;
    public bool UnlockClickAnywhere = true;

    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (!animationIsplaying)
        {
            if (Input.GetKey(KeyCode.W) && startY == transform.position.y && gameStarted)
            {
                animationIsplaying = true;
                playerJump();
                playerBody.enabled = false;
                playerBodyDucked.enabled = true;


            }
        }
        
        if (Input.GetKeyDown(KeyCode.S) && gameStarted)
        {
            CharAnimator.Play("CharAnimation");
            playerBody.enabled = false;
            playerBodyDucked.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.S) && gameStarted)
        {
            CharAnimator.Play("Idle");
            

        }
        if (rotateCouroutineFinished && gameStarted && !lengthCoroutineIsRunning)
        {
            StartCoroutine(AnimateLength(lengthCurve, animationTime));
            lengthCoroutineIsRunning = true;
        }
        if (gameStarted && !lengthCoroutineIsRunning && coroutineswitch)
        {
            StartCoroutine(InvertedAnimateLength(lengthCurve, animationTime));
            lengthCoroutineIsRunning = true;

        }

        
      
        
            
                
            
            



                if (!animationIsplaying)
                {
                    if (swipeControls.SwipeUp && startY == transform.position.y && gameStarted)
                    {
                        animationIsplaying = true;
                        playerJump();
                        playerBody.enabled = false;
                        playerBodyDucked.enabled = true;

                    }

                }
                if (Input.GetMouseButtonDown(0) && gameStarted)
                {
                    CharAnimator.Play("CharAnimation");
                    playerBody.enabled = false;
                    playerBodyDucked.enabled = true;
                }
                if (Input.GetMouseButtonUp(0) && gameStarted && !animationIsplaying)
                {
                    CharAnimator.Play("Idle");
                    
                    
                }
                
            

            
        
    }

    public void StopPlayerIntroAnimation()
    {
        GetComponent<Animator>().enabled = false;
    }



    public void playerJump()
    {
        StopAllCoroutines();
        CharAnimator.Play("CharAnimation");
        StartCoroutine(AnimateHeight(heightCurve, animationTime));
        StartCoroutine(AnimateRotate(RotationCurve, animationTime));
    }


    IEnumerator AnimateHeight(AnimationCurve Curve, float totalTime)
    {
        float timer = 0;
        while (timer <= totalTime)
        {
            transform.Translate(0, 1 * Curve.Evaluate(timer / totalTime) / jumpHeightDiv, 0, Space.World);
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }
        transform.position = new Vector2(transform.position.x, startY);

    }


    IEnumerator AnimateRotate(AnimationCurve Curve, float totalTime)
    {
        float timer = 0;
        while (timer <= totalTime)
        {
            transform.Rotate(0, 0, 1 * (Curve.Evaluate(timer / totalTime) * rotationMult));
            Debug.Log(Curve.Evaluate(timer / totalTime));
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = new Vector2(transform.position.x, startY);
        rotateCouroutineFinished = true;
        CharAnimator.Play("Idle");
        playerBody.enabled = true;
        playerBodyDucked.enabled = false;
        
    }

    IEnumerator AnimateLength(AnimationCurve Curve, float totalTime)
    {
        float timer = 0;
        while (timer <= totalTime)
        {
            transform.Translate(1 * Curve.Evaluate(timer / totalTime) / jumpLengthDiv, 0, 0, Space.World);
            timer += Time.deltaTime * 4;
            yield return new WaitForFixedUpdate();

        }
        lengthCoroutineIsRunning = false;
        coroutineswitch = true;
        rotateCouroutineFinished = false;
        
    }

    IEnumerator InvertedAnimateLength(AnimationCurve Curve, float totalTime)
    {
        float timer = totalTime;
        while (timer >= totalTime / 2)
        {
            transform.Translate(1 * Curve.Evaluate(timer / totalTime) / jumpLengthDiv / 1.5f, 0, 0, Space.World);
            timer -= Time.deltaTime * 4;
            yield return new WaitForFixedUpdate();

        }
        lengthCoroutineIsRunning = false;
        coroutineswitch = false;
        animationIsplaying = false;
        
    }

 
    
}
