using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShark : MonoBehaviour
{
    public float linearSpeed = -0.35f;
    public static bool gameStarted = false;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("hit by Moving Shark");
            //SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitBarrel);
            GameObject.Find("ScriptManager").GetComponent<GameManager>().PlayerGotHit();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted) transform.Translate(linearSpeed, 0, 0);
    }



}
