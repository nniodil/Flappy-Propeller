using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    public int score;
    public int currentScore;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI scoreText;
    public GameObject scorePanel;

    [Header("Pipelines")]
    public GameObject[] Pipelines;
    public bool canSpawn = true;
    
    [Header("GameOver")]
    public GameObject gameOverPanel;
    public bool gameOver = true;
    

    void Start()
    {
        
        
        gameOver = false;
    }

    void Update()
    {
        Text();
        SpawnPipeline();
        GameOver();
    }

    void SpawnPipeline()
    {
        if (!gameOver) 
        {
            if (canSpawn)
            {
                //Random pipelines
                canSpawn = false;
                int index = Random.Range(0, Pipelines.Length);
                Instantiate(Pipelines[index]);
                StartCoroutine(SpawnDelay());

            }

            IEnumerator SpawnDelay()
            {
                yield return new WaitForSeconds(1.5f);
                canSpawn = true;
            }

        }  
    }

    void GameOver()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            scorePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!gameOver)
        {
            gameOverPanel.SetActive(false);
            scorePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
    
    }


    void Text()
    {
        currentScoreText.text = currentScore.ToString();
        scoreText.text = "Score :  " + currentScore.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Flappy Propeller");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
