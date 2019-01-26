using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_behavor : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hit bird");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
