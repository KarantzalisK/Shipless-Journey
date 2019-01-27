using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColliderToIdle : MonoBehaviour
{
    public void IdleColliderEnable()
    {
        FindObjectOfType<Player>().playerBody.enabled = true;
        FindObjectOfType<Player>().playerBodyDucked.enabled = false;
    }
}
