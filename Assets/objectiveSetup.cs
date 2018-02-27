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
    public float testArea = 15f;
    Vector3 downCast(Vector3 fireCoordinates)
    {
        int loopCount = 0; 
        bool hitHere = false;
        while (!hitHere)
        {
            RaycastHit hit;
            if (Physics.Raycast(fireCoordinates, -Vector3.up, out hit))
            {
                Debug.DrawRay(fireCoordinates, -Vector3.up * (downRange * 2), Color.red, 15f);
                //print("Found an object - distance: " + hit.distance + hit.collider.name);
                if (hit.collider.gameObject.GetComponent("Terrain") != null)
                {

                    RaycastHit hit2;
                    Vector3 p1 = hit.point;
                    float distanceToObstacle = 0;
                    // Cast a sphere wrapping character controller 10 meters forward
                    // to see if it is about to hit anything.
                    if (Physics.SphereCast(p1, testArea, transform.forward, out hit2, 10))
                    {
                        distanceToObstacle = hit2.distance;
                        if(hit2.collider.gameObject.GetComponent("Terrain") != null)
                        {

                        }
                        else
                        {
                            hitTarget = false;
                            break;
                        }
                    } //Don't spawn here too close to thing
                    {
                        fireCoordinates = hit.point;
                        fireCoordinates.y += spawnOffset;
                        Debug.LogWarning("Hit collider: " + hit.collider.name);
                        hitHere = true;
                        hitTarget = true;
                        break;
                    }
                }
                else
                {
                    if(loopCount > 64)
                    {
                        hitTarget = false;
                        break;
                    }
                    //get new random range
                    loopCount++;
                    randomRangeHitPoint();
                }
            }
            //Debug.Log(hit.collider.name);
        }

        return fireCoordinates;
    }

    Vector3 randomRangeHitPoint()
    {
        Vector3 fireHere = new Vector3(Random.Range(firePoint.x - (landTarget.terrainData.size.x / 2), firePoint.x - ((landTarget.terrainData.size.x / 2) * 3)), firePoint.y + downRange, Random.Range(firePoint.z - (landTarget.terrainData.size.z / 2), firePoint.z - ((landTarget.terrainData.size.z / 2) * 3)));
        return fireHere;
    }

    bool hitTarget = false;
    float timeTill;
    public float count;
	// Update is called once per frame
	void Update () {
        //targets.Length
        ////////if(targets_Minimum > targets.Length)
        if(timeTill < Time.time && Objective_Container.childCount < targets_Minimum)
        {
            timeTill = Time.time + count;
            //Vector3 fireHere = new Vector3(Random.Range(firePoint.x - (landTarget.terrainData.size.x / 2), firePoint.x - ((landTarget.terrainData.size.x / 2) * 3)), firePoint.y + downRange, Random.Range(firePoint.z - (landTarget.terrainData.size.z / 2), firePoint.z - ((landTarget.terrainData.size.z / 2) * 3)));
            Vector3 instantiateHere = downCast(randomRangeHitPoint());
            if (hitTarget)
            {
                GameObject spawn = Instantiate(instantiate_This, instantiateHere + new Vector3(0, 2, 0), Quaternion.identity, Objective_Container) as GameObject;
            }
            hitTarget = false;
            //targets.le
        }
		
	}
}
