using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float linearSpeed = -0.35f;


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
        if (col.gameObject.tag.Equals("Ship"))
        {
            Debug.Log("hit Hard");
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitBarrel);
            linearSpeed = 0;
            FindObjectOfType<ShipMovement>().HitOnRock();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStarted) transform.Translate(linearSpeed, 0, 0);

    }





}
