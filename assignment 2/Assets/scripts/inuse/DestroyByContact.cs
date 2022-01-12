using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public  int ScoreValue;
    private GameController gameController;

    void Start()
    {
        // getting game controller scrpit 
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log(" cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // instantiating explosion 'effect' when collision is triggered 
        if(other.tag =="Boundary"|| other.tag == "Enemies")
        {
            return;
        }

        if ( explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Debug.Log("shothit");
        }
        
        // if the player has an explosion then game is over 
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            Debug.Log("playerhit");
        }
        gameController.AddScore(ScoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}
