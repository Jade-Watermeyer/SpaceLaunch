using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    // destroy objects that leave the boundary so they are no longer valid in game play 

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        
    }

}
