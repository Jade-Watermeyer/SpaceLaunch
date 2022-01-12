using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // moving the lazers on both enemy and player 
    public float speed;
    public Rigidbody rigidbody;


    void Start()
    {
        rigidbody.velocity = transform.forward * speed;
        
    }
}
