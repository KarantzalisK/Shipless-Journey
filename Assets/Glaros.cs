using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glaros : MonoBehaviour
{
    public float linearSpeed = -0.35f;


    private float startY;
    private float startX;
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
        if (gameStarted)
        {
            transform.Translate(linearSpeed, 0, 0);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("hit Hard");
            //SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitBarrel);
            GameObject.Find("ScriptManager").GetComponent<GameManager>().PlayerGotHit();
        }

    }

}
