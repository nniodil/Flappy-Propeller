using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Header("Components")]
    public GameManager gameManager;
    
    [Header("ResetPos")]
    private Vector3 resetPos; 
    private float resetPosX = -9.95f;

    public float speed;


    void Start()
    {
        //Vector3 of platform position reset
        resetPos = new Vector3(resetPosX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        MovementLoop();
    }
    void MovementLoop()
    {
        if (!gameManager.gameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }       
        if (transform.position.x < -24.7f)
        {
            transform.position = resetPos;
        }
    }
}
