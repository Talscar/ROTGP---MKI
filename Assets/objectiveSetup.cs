using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveSetup : MonoBehaviour {

    public GameObject instantiate_This;

    public static Transform Objective; //Think of a compass and think of this as a pointer!
    public Transform Objective_Container;

    public GameObject[] targets;
    public int targets_Minimum;
    public Terrain landTarget;
    public float downRange = 250f;
    public float spawnOffset = 0.5f;
    Vector3 firePoint;
    // Use this for initialization
    void Start()
    {
        firePoint = new Vector3(transform.position.x + (landTarget.terrainData.size.x / 2), downRange /*+ landTarget.terrainData.size.y + (landTarget.terrainData.size.y / 2)*/, landTarget.terrainData.size.z + (landTarget.terrainData.size.z / 2));
        Debug.LogError("Down range is failing to work appropriately.");
    }

    Vector3 downCast(Vector3 fireCoordinates)
    {
        bool hitHere = false;
        //while (!hitHere)
        //{
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                print("Found an object - distance: " + hit.distance);
                if (hit.collider.GetComponent("Terrain") != null)
                {
                fireCoordinates = hit.point;
                    hitHere = true;
                    //break;
                }
            }
        //}

        return fireCoordinates;
    }



    float timeTill;
    public float count;
	// Update is called once per frame
	void Update () {
        //targets.Length
        ////////if(targets_Minimum > targets.Length)
        if(timeTill < Time.time)
        {
            timeTill = Time.time + count;
            Vector3 fireHere = new Vector3(Random.Range(firePoint.x - (landTarget.terrainData.size.x / 2), firePoint.x - ((landTarget.terrainData.size.x / 2) * 3)), firePoint.y, Random.Range(firePoint.z - (landTarget.terrainData.size.z / 2), firePoint.z - ((landTarget.terrainData.size.z / 2) * 3)));
            Vector3 instantiateHere = downCast(fireHere);
            GameObject spawn = Instantiate(instantiate_This, instantiateHere + new Vector3(0, 2, 0), Quaternion.identity, Objective_Container) as GameObject;
            //targets.le
        }
		
	}
}
