using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navData : MonoBehaviour {

    [Tooltip("How many regions accross the terrain? (10, 10), (1, 1), (111, 111)")]
    public int regionSensitivity = 10; //Makes region design squared.
    float regionSquare = 50f;
    /*
    * Bounds[]
    * Boundry
    */

    /*
     * Boundry
     * Vector3 bound
     * bool xPos
     * bool zPos
     * //Pos refering to the boundry being in a positive direction or negitive. 
     */
    public float free = 3.33f;

     [System.Serializable] public struct regionalData
    {
        [SerializeField]public bool avoidThisRegion;
        [SerializeField]public boundryPoint[] bounds;
    }

    //x,z regional data
    public regionalData[,] regions;// = new regionalData();
    
    //[System.Serializable]
    //public struct region
    //{
    //    public regionalData regionX;
    //}
        //AI could choose a Short, Long or pick random route.

    void returnRegionScale()
    {
        float longestAxis;
        //regionSensitivity
        //regionSquare
        if(gameObject.GetComponent("Terrain") != null)
        {
            TerrainData dataT = gameObject.GetComponent<Terrain>().GetComponent<TerrainData>();

            if(dataT.size.x > dataT.size.z)
            {
                longestAxis = dataT.size.x;
            }
            else
            {
                longestAxis = dataT.size.z;
            }
            regionSquare = longestAxis / regionSensitivity;
            //do something with this terrain scale length and width.
        }
        else
        {
            Debug.LogError("navData.cs ERROR: (returnRegionScale();) " + " No supported format exists for this data type!");
        }
        return;
    }


    void navigation()
    {
        returnRegionScale();    //Find the scale of the region map space.
        regions = new regionalData[regionSensitivity, regionSensitivity];//{ { new regionalData[regionSquare], new regionalData[regionSquare]};//Set the map region space too (x, z) regions for this data type.

        //Dummy learning
        regions[0, 0].avoidThisRegion = true;
        regions[0, 0].bounds[0].m_bound = transform.position;
        //Dummy learning


    }

    /*
     * Get the 2 Dimentinal area in which the terrain will be scaled for navigation for the AI.
     * Scan in all gameObjects that will Obstruct the player.
     * For each region, check for any static Obstruction for rerouting player in region. 
     */

    void boundGen() //Foreach region in editor or at runtime. (Would take a while to calculate based on sensitivity for regions.)
    {
        GameObject[] scene = GameObject.FindGameObjectsWithTag("Navigation");  //returns GameObject[]
                                                                               //GameObject[] scenea = GameObject.find

        foreach(GameObject obsticle in scene)
        {
            Vector3 centerAverage;
        }
        /*
         * Foreach gameObject with tag of Navigation
         * identify the area in which each occupies 
         */

        //GameObject[] scene = GameObject.g
        //foreach(GameObject)
        //Bounds data;
        //data = new Bounds(bou);
        regions[0, 0].avoidThisRegion = true;
        regions[0, 0].bounds[0].m_bound = transform.position;
        ////////////////////////////boundryPoint data = new boundryPoint(new Vector3(3,3,3), true, true); 
        return;
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //Gizmos.DrawSphere(this.transform.position, 1);
    //}


    void clearBoundGen()
    {

    }
    void saveBoundGen()
    {

    }
    void loadBoundGen()
    {

    }

}








    ///////////////* pathCalculation
    ////////////// * float distance
    ////////////// * Vector3[] point
    ////////////// */

    //////////////    struct boundry
    //////////////{
    //////////////    public Vector3 bound;
    //////////////    public bool xPos;
    //////////////    public bool zPos;
    //////////////}