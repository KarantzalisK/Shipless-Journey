using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shark : MonoBehaviour
{
    
    public float speed = 0;
    public GameObject shark;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerCollisionEnter2D(Collision2D collision)
    {
        speed = 2;
        transform.Translate(Vector3.forward * 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
