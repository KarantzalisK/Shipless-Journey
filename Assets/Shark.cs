using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public float linearSpeed=-0.35f;
    public float animationTime = 0.5f;
    public float jumpHeightDiv = 2;
    public float rotationMult = 5;

    private float startY;
    private float startX;
    public AnimationCurve heightCurve;
    public AnimationCurve RotationCurve;
    private bool onAir=false;
    public static bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        startX = transform.position.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!onAir && gameStarted)
        {
            transform.Translate(linearSpeed, 0, 0);
        }
        //if (Input.GetKey(KeyCode.P) && startY == transform.position.y)
        //{
        //    SharkJump();
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("JumpPosition")) {
            onAir = true;
            SharkJump();
            
        }else if (collision.gameObject.tag.Equals("Player")){
                Debug.Log("hit Hard");
                //SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitBarrel);
                GameObject.Find("ScriptManager").GetComponent<GameManager>().PlayerGotHit();
        }
        
    }

    public void SharkJump()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateHeight(heightCurve, animationTime));
        StartCoroutine(AnimateRotate(RotationCurve, animationTime));
    }


    IEnumerator AnimateHeight(AnimationCurve Curve, float totalTime)
    {
        float timer = 0;
        while (timer <= totalTime)
        {
            transform.Translate(linearSpeed, 1 * (Curve.Evaluate(timer / totalTime)/jumpHeightDiv), 0, Space.World);
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }
       // transform.position = new Vector2(transform.position.x, startY);

    }


    IEnumerator AnimateRotate(AnimationCurve Curve, float totalTime)
    {
        float timer = 0;
        while (timer <= totalTime)
        {
            transform.Rotate(0, 0, -1 * (Curve.Evaluate(timer / totalTime) * rotationMult));
            Debug.Log(Curve.Evaluate(timer / totalTime));
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = new Vector2(transform.position.x, startY);
        onAir = false;
    }

    public void resetSharkPos() {
        transform.position = new Vector2(startX,startY);

    }

}
