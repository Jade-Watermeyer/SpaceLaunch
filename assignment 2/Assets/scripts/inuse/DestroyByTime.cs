using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    //destry explotion effect after a certain about of time 

    public float lifetime; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
        Debug.Log("where you");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
