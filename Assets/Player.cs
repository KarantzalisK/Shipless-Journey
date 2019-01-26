using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    
    public float mult = 1F;
    public AnimationCurve heightCurve;
    public AnimationCurve RotationCurve;
    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 0);
        if (Input.GetKey(KeyCode.W)&&startY==transform.position.y) {
            playerJump();
        }
    }

    

    public void playerJump() {
        StopAllCoroutines();
        StartCoroutine(AnimateMove(heightCurve, 0.5f));
        StartCoroutine(AnimateMove2(RotationCurve, 0.5f));
    }


    IEnumerator AnimateMove(AnimationCurve Curve,float totalTime)
    {
        float timer = 0;
        while (timer<=totalTime) {
            transform.Translate(0, 1*(Curve.Evaluate(timer / totalTime)/4), 0, Space.World);
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }
        transform.position = new Vector2(transform.position.x, startY);

    }


    IEnumerator AnimateMove2(AnimationCurve Curve, float totalTime)
    {
        float timer = 0;
        while (timer <=totalTime)
        {
            transform.Rotate(0,0, 1 * (Curve.Evaluate(timer / totalTime)*5));
            Debug.Log(Curve.Evaluate(timer / totalTime));
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }
        transform.rotation = new Quaternion(0,0,0,0);
        transform.position = new Vector2(transform.position.x, startY);

    }


    public void playerDuck() {

    }

}
