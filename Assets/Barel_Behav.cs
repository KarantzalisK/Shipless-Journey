using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barel_Behav : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hit barel");
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitBarrel);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
