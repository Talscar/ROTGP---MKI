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


    bool whileMovement;
    void movement(bool moving)
    {
        whileMovement = moving;
    }


    void Update()
    {
        if(whileMovement)
        {
            //The player is moving

            //The player is moving
        }
    }
}
