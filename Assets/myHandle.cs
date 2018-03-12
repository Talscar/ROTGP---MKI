using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myHandle : MonoBehaviour {

    //A permanant object that is instantiated at the compass for the player and the players instatiate reference is aded to DirectionFromSelf.
    //The Player will be able to see this compass pointer facing food when empty and requested by the target location.
    //Requires more technical detail.

    //Compass does not work yet!
    public float angle;

    public Color myColor = Color.gray;

    public Transform DirectionFromSelf;
    public Transform target;
    float speed = 15f;

	// Use this for initialization
	void Start () {
        Debug.LogError("Incomplete script! Compass = myHandle.cs");
	}
	
	// Update is called once per frame
	void Update () {

        if(target != null)
        {
            Vector3 dir = target.position - DirectionFromSelf.position;

            angle = Vector3.Angle(DirectionFromSelf.position, dir);

            transform.eulerAngles = new Vector3(0, /*newDir.z*/0, angle);

            ////////Vector3 customRot = new Vector3() - new Vector3()

            //////Vector3 targetDir = target.position - DirectionFromSelf.transform.position;
            //////float step = speed * Time.deltaTime;
            //////Vector3 newDir = Vector3.RotateTowards(DirectionFromSelf.transform.forward, targetDir, step, 0.0F);
            //////Debug.DrawRay(DirectionFromSelf.transform.position, newDir, Color.red);

            //////float angle = Vector3.Angle(DirectionFromSelf.transform.position, /*targetDir*/target.position);

            ////////Vector3 direction = 
            ////////transform.rotation = Quaternion.LookRotation(newDir);
            ////////transform.eulerAngles = new Vector3(0, /*newDir.z*/0, angle);
            //////transform.eulerAngles = new Vector3(0, /*newDir.z*/0, targetDir.z * 360);

        }

    }

    //public float speed;
    //void Update()
    //{
    //    Vector3 targetDir = target.position - transform.position;
    //    float step = speed * Time.deltaTime;
    //    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
    //    Debug.DrawRay(transform.position, newDir, Color.red);
    //    transform.rotation = Quaternion.LookRotation(newDir);
    //}
}
