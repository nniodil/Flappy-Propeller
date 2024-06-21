using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    CharacterController characterController;
    public GameManager gameManager;

    [Header("Jump")]
    public AudioSource jumpSound;
    public Vector3 velocity;
    public float gravity;
    public bool canJump = true;
    public float jumpForce;

    void Start()
    {
        //Find References
        characterController = GetComponent<CharacterController>();
        jumpSound = GameObject.Find("jump").GetComponent<AudioSource>();
    }


    void Update()
    {
        Movement();
    }

    void Movement()
    {
        characterController.Move(Vector3.up * velocity.y * Time.deltaTime);

        //Rotate to falling rotation when gameOver
        if (gameManager.gameOver)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -45);

        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        
        //Jump
        if (!gameManager.gameOver)
        {

            velocity.y += gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) && canJump)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
                canJump = false;
                jumpSound.Play();
                StartCoroutine(JumpDelay());
            }

            IEnumerator JumpDelay()
            {
                yield return new WaitForSeconds(0.1f);
                canJump = true;
            }
        }
        else if (gameManager.gameOver) 
        {
            velocity.y = -10;
        }

         
    }

}
