using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class artificialController : MonoBehaviour {

    /*
     * Check the states in which the AI needs
     * 
     * Does have target? Transform != null && isObjective
     * Player ahead = More score
     * 
     * Does have Ability?
    */
    public Transform target;

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(target.position, path);
        if (path.status == NavMeshPathStatus.PathPartial)
        {
        }
    }

    void repath()
    {
        //Raycasts will identify a target in front obstructing the player.
        //Target blocking play will be messured to a point the player could be diverted.
        //Custom vector2 can be used to repath the players coordinates to help direct the player to the goal.

        //Draw path between A and B.
        //If can not reach location then try finding spaces at the object bounds.
        // Once found, recheck the path and if player can reach objective then go!
        //If not repeat previous steps.
    }
    //Unity AI NavMesh
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    //https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html


    public movementController myController;
    //public 

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () {
		
	}
}
