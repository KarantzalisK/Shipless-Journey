using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndIsland : MonoBehaviour
{
    public float linearSpeed = -0.35f;
    public static bool gameStarted = false;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("EndIsland");
            //SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitBarrel);
           
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStarted) transform.Translate(linearSpeed, 0, 0);
    }



}
