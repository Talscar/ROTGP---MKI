﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour {

    [Tooltip("Could be anything from a script to process too a item to replace something else. \n Prefrably a scriptable GameObject")]
    public StatusEffect[] PickupEffect;
    public bool destroyOnEnter = true;
    // Use this for initialization
	void Start () {
        //Works with all scripts based on what values collection passes onto scripts or pickup

        //foreach (Object runMe in Pickup) //Multiple items to run and use
        //{
        //    if (runMe is StatusEffect)
        //    {
        //        Debug.Log("Process this thing: " + runMe);
        //    }
        //    Debug.Log("what is thing?  " + runMe);
        //}


    }

    void OnTriggerEnter(Collider Other)
    {
        Debug.Log("Collision");
        if(Other.gameObject.GetComponent("movementController") != null)
        {
            movementController theActor = Other.gameObject.GetComponent<movementController>();
            if (PickupEffect.Length > 0)
            {
                //theActor.inflicted = PickupEffect;
                theActor.moreThanOneEffect(PickupEffect);
            }
            //Debug.Log(Pickup.GetInstanceID());
            //if(Pickup.GetInstanceID() != float)
            //{

            //}
            //Pickup[0].h
            //collider.gameObject.GetComponent<movementController>().inflicted = Pickup[0].GetType("StatusEffect");
        }
        if(destroyOnEnter)
        {
            Debug.LogWarning("Play Effects!");
            Destroy(this.gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
