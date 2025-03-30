using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;
    private float verticalHalfLimit = 6.0f;
    private float verticalObjectBottom = 2.5f;

    public GameObject bulletPrefab;

    void Start()
    {
        playerSpeed = 6f;
        //This function is called at the start of the game

    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();

    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        //Player leaves the screen horizontally
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        //Task 1: stops player from going off the bottom of the screen or past the middle of the screen by using a Mathf.Clamp function and limiting the player's vertical movement. The "verticalHalfLimit" variable represents the middle of the screen and the "verticalObjectBottom" variable accounts for the bottom of the player that would go be cut off at the bottom of the screen.
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, verticalScreenLimit * -1 + verticalObjectBottom, verticalScreenLimit - verticalHalfLimit);
        transform.position = viewPos;
        
        
    }

}