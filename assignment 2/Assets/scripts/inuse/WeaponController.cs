using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // controlling the BB enemy lazer movemnts and rates 
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    

    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("Fire", delay, fireRate);
    }
    void Fire()
    {
         //Quaternion spawnRotation = Quaternion.Euler(0,270,0);
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
       
    }

    
}
