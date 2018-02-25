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
    public Transform players;
    public Transform containerObjectives;
    public Transform target;

    [SerializeField]private Vector3 moveToHere;
    [SerializeField]private Vector3 node; 

    //private NavMeshAgent agent;
    void Start()
    {
        if (GetComponent("movementController") != null)
            myController = GetComponent<movementController>();

        //agent = GetComponent<NavMeshAgent>();
        //NavMeshPath path = new NavMeshPath();
        //agent.CalculatePath(target.position, path);
        //if (path.status == NavMeshPathStatus.PathPartial)
        //{
        //}
    }

    Transform getTarget(Transform newTarget)
    {
        if(containerObjectives != null)
        {
            if(containerObjectives.GetComponentInChildren<Transform>() != null)
            {
                bool first = true;
                //Transform newTarget;
                float distance = float.MaxValue;
                Transform[] targets = containerObjectives.GetComponentsInChildren<Transform>();
                foreach(Transform child in targets)
                {
                    float testDistance = Vector3.Distance(child.position, transform.position);
                    if(first)
                    {
                        newTarget = child;
                        distance = testDistance;
                    }
                    else
                    {
                        if(testDistance < distance)
                        {
                            newTarget = child;
                            distance = testDistance;
                        }
                    }
                }
            }
        }
        return newTarget;
    }


    /// <summary>
    /// Using Primitives.
    /// </summary>
    void repath(Vector3 currentMoveLocation)
    {

        Vector3 targetDirection =  target.position - transform.position;
        var distance = targetDirection.magnitude;

        var direction = targetDirection / distance;
        //Debug.Log(direction);

        dir = new Vector2(direction.x, direction.z);
        //Debug.Log(targetDirection);
        //https://docs.unity3d.com/Manual/editor-CustomEditors.html
        //Raycasts will identify a target in front obstructing the player.
        //Target blocking play will be messured to a point the player could be diverted.
        //Custom vector2 can be used to repath the players coordinates to help direct the player to the goal.

        //Draw path between A and B.
        //If can not reach location then try finding spaces at the object bounds.
        // Once found, recheck the path and if player can reach objective then go!
        //If not repeat previous steps.
        return;
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
    Vector2 dir;
	void Update ()
    {
        if (myController != null)
        {
            if(myController.identifier_IsAI)
            {
                Debug.Log("Check!");
                if (target != null)
                {
                    repath(target.position);
                    //Debug.Log(dir);
                    myController.getNewDirection(dir);
                }//myController.dir
                else
                {
                    Debug.Log("Check! ELSE");
                    dir.x = 0;
                    dir.y = 0;
                    myController.getNewDirection(dir);
                    target = getTarget(null);
                }
            }
        }
		
	}
}
