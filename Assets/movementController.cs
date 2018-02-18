using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour {

    //I am the controller... but no one can just control me.
    //I am given a controller at start by the game manager or if a player drops off the service I can be given a AI in it's place.
    //While I am told to do actions, I will move things based on what inputs I have been given.
    //Should no players be present the game will end according to the server rules.

    //Functions for movement
    //Controller/Gamepad/Touchpad/Mouse and Keyboard.

    //Function for my score

    //Function for my own interactions

    //Function to use Powerups in my possession.
    //bool whileMovement;
    //void movement(bool moving)
    //{
    //    whileMovement = moving;
    //}


    //void Update()
    //{
    //    if(whileMovement)
    //    {
    //        //The player is moving

    //        //The player is moving
    //    }
    //}

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    float speed = 10f;
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        //////Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"),Input.GetAxis("Vertical"));


        ////////transform.position += moveDirection;
        //////rb.AddForce(moveDirection * speed);

    }
}
