using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour {

    [Tooltip("Could be anything from a script to process too a item to replace something else. \n Prefrably a scriptable GameObject")]
    public Object[] Pickup;	
    // Use this for initialization
	void Start () {
        //Works with all scripts based on what values collection passes onto scripts or pickup

        foreach (Object runMe in Pickup) //Multiple items to run and use
        {
            if (runMe is StatusEffect)
            {
                Debug.Log("Process this thing: " + runMe);
            }
            Debug.Log("what is thing?  " + runMe);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
