using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whisk : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log(1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.GetComponent<Bowl>());
    }
}
