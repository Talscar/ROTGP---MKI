using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class boundryPoint
{
    public Vector3 m_bound = new Vector3();
    public bool m_xPos = new bool();
    public bool m_zPos = new bool();

    /// <summary>
    /// Boundry points for custom Navigation within the enviroment.
    /// </summary>
    /// <param name="bound">The Vector point for which is within the vector perimeter.</param>
    /// <param name="xPositive">If bounds is positive of the bound, then this is positive.</param>
    /// <param name="zPositive">If bounds is positive of the bound, then this is positive.</param>
    //[DefaultMember("Item")]
    //[UsedByNativeCodeAttribute]
    public boundryPoint(Vector3 bound, bool xPositive, bool zPositive)
    {
        m_bound = bound;
        m_xPos = xPositive;
        m_zPos = zPositive;
    }

    //public boundryPoint() { Get, Set };
    //public float CompareTo(boundryPoint other)
    //{
    //    if (other == null)
    //    {
    //        return 1f;
    //    }

    //    //Return the difference in power.
    //    return m_bound.x - other.m_bound.x;
    //}

}

////////////////using System.Reflection;
////////////////using UnityEngine.Internal;
////////////////using UnityEngine.Scripting;

//////////////////[System.Serializable]
////////////////namespace CP_Navigation
////////////////{
////////////////    [DefaultMember("Item")]
////////////////    [UsedByNativeCodeAttribute]
////////////////    public struct boundryPoint
////////////////    {

////////////////        public Vector3 bound;
////////////////        public bool xPositive;
////////////////        public bool zPositive;

////////////////        public boundryPoint(Vector3 bound, bool xPositive, bool zPositive);

////////////////        public float this[int index] { get; set; }
////////////////    }
////////////////}