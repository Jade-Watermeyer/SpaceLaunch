using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject Boss;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
        StartCoroutine(SpawnWave());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene("SpaceLaunch");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    IEnumerator SpawnWaves ()
    {
        //spawning normal red enemies 
        yield return new WaitForSeconds(startWait);
        while (true) 
        {
            for (int i =0; i <hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
            //how to restart the game using a key 
            if (gameOver)
            {
                restartText.text = "press 'R' for Restart";
                restart = true;
                break;
            }
        }


    }
    IEnumerator SpawnWave()
    {
        //spawning yellow BB enemies- shoot back at player 
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 1; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.Euler(0,180,0);
                Instantiate(Boss, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            // how to restart - repeated as its to different conditions for the game to end 
            if (gameOver)
            {
                restartText.text = "press 'R' for Restart";
                restart = true;
                break;
            }
        }


    }
    // adding the score when collision is detected between player lazer and enemy 
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "score: " + score;
    }
    // disply end game text when game over conditions are met 
    public void GameOver()
    {
        
        gameOverText.text = "Game Over";
        gameOver = true; 
    }

}