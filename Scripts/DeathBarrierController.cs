using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrierController : MonoBehaviour
{
    [Header("Components")]
    public GameManager gameManager;
    public AudioSource dieSound;


    void Start()
    {
        //Find References
        gameManager = FindAnyObjectByType<GameManager>();
        dieSound = GameObject.Find("die").GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // if he collide with the barrier = gameOver
        if (other.CompareTag("Player"))
        {
            gameManager.gameOver = true;
            
        }
        if (other.CompareTag("Player") && gameObject.CompareTag("Platform"))
        {
            dieSound.Play();
        }
    }
}
