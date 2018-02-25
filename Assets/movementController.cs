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
    public bool identifier_IsAI = false;

    public StatusEffect inflicted;

    Rigidbody rb;
    void Start()
    {
        //if(ai)
        rb = GetComponent<Rigidbody>();
        inflicted.Initialize(this.gameObject);
    }

    public void newObjective(Transform objective)
    {

    }
    //public bool allowMovement = false;
    public static bool canMove = true;

    public float forceFactor = 10f;
    public float speed = 10f;
    public float rotSpeed = 15f;
    //float moveSpeed;
    public void getNewDirection(Vector2 theDirection)
    {
        dirAi = theDirection;
    }
    Vector2 dirAi = new Vector2(0f, 0f); //Simulated by he Ai;
    void Update()
    {
        //if(allowMovement && !canMove)
        //{
        //    canMove = true;
        //}
        //else
   
        if (canMove)
        { //Can move based on Game Start Timer.
            float x = dirAi.x;// = Input.GetAxis("Horizontal");// * Time.deltaTime * 150.0f;
            float z = dirAi.y;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            if (!identifier_IsAI)
            {
                x = Input.GetAxis("Horizontal");// * Time.deltaTime * 150.0f;
                z = Input.GetAxis("Vertical");// * Time.deltaTime * 3.0f) * speed;
            }

            Vector3 dir = new Vector3(x, 0, z);

            //         1
            //         |
            //         |
            // -1______+______ 1
            //         |
            //         |
            //        -1

            Vector3 targetDir = (dir + transform.position) - transform.position;
            float step = rotSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
            //float moveDir ;
            float mF = 0f;
            if (z != 0 || x != 0)
            {
                float newZ = Mathf.Abs(z);
                float newX = Mathf.Abs(x);
                if (newZ > newX)
                {
                    mF = newZ;
                }
                else
                {
                    mF = newX;
                }
                mF = mF * speed;
                //mF = newZ * newX;
                //mF
            }
            //else if(z < 0 || x < 0)
            //{
            //    mF = -1f;
            //}

            rb.velocity += transform.forward * ((mF * Time.deltaTime * 3.0f) * forceFactor);
            //transform.Rotate(0, x, 0);
            ////transform.Translate(0, 0, z);


            //Vector3 moveDirection = new Vector3(0, 0, z);
            ////rb.MovePosition(moveDirection * speed);//(Vector3.forward * (speed * z));
            ////rb.AddForce(Vector3.forward * 1000);
            //rb.velocity += transform.forward * (z * forceFactor);

            if (inflicted != null)
            {

            }
            //////Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"),Input.GetAxis("Vertical"));

            if (inflicted != null)
            {
                inflicted.TriggerAbility();
            }
        } //canMove (Based on game start timer)


        //if(Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    inflicted.TriggerAbility();
        //    //inflicted.Initialize(this.gameObject);
        //}
        ////////transform.position += moveDirection;
        //////rb.AddForce(moveDirection * speed);

    }

    //public Ability[] statusEffect;

    //[System.Serializable]public struct statusModifier
    //{

    //}
    public void moreThanOneEffect(StatusEffect[] effects)
    {
        foreach(StatusEffect effect in effects)
        {
            inflicted = effect;
            statusProcessor(effect.Effect, effect);
        }
        return;
    }
    public void statusProcessor(StatusEffect.dataTypes data, Ability _this)
    {
        if (inflicted != null)
            switch (data)
            {
                case StatusEffect.dataTypes.scale:
                    gameObject.transform.localScale = transform.localScale * inflicted.Scale.scalePercent;
                    break;

                case StatusEffect.dataTypes.speed:
                    speed = speed * inflicted.Speed.speedPercent;
                    break;

                case StatusEffect.dataTypes.knockback:
                    break;
            }

        Debug.Log("Processing the StatusEffect!");
        inflicted = null;

        return;
    }
}

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