using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineController : MonoBehaviour
{
    [Header("Components")]
    public GameManager gameManager;
    public AudioSource scoreSound;

    public float speed;

    void Start()
    {
        //Find References
        gameManager = FindAnyObjectByType<GameManager>();
        scoreSound = GameObject.Find("score").GetComponent<AudioSource>();
    }
    
    void Update()
    {
        Movement();
    }
    
    void Movement()
    {
        // Move towards player
        if (!gameManager.gameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        // destroy when off screen
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // score when going through pipeline
        if (other.CompareTag("Player"))
        {
            gameManager.currentScore++; 
            scoreSound.Play();
        }
        // gameOver when hit pipeline 
        if (other.CompareTag("Player") && gameObject.CompareTag("Pipeline"))
        {
            gameManager.gameOver = true;

        }
    }

}
