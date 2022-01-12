using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    // cause the enemies to rotate in random directions- not stationary 
    public float tumble;
    public Rigidbody rigidbody;

    void Start()
    {
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
