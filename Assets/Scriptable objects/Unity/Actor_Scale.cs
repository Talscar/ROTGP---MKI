using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Abilities/ProjectileAbility")]
public class Actor_Scale : Ability {

    public bool hasScaleAlteration = false;
    [Tooltip("1 is equal to 100%. So 0 is equal to 0% and 2 = 200%. \n This value sets the current scale of something by a percentage.")]
    [Range(0f, 2f)]
    public float scalePercent = 1f;

    bool hasSpeedAlteration = false;
    [Tooltip("1 is equal to 100%. So 0 is equal to 0% and 15 = 1500%. \n This value sets the current speed of something by a percentage." )]
    [Range(0f, 15f)]
    public float speedPercent = 1f;


    bool hasDuration = false;
    [Tooltip("How many seconds this ability will run for!")]
    [Range(1f, 15f)]
    public float duration = 1f;


    //////public float projectileForce = 500f;
    //////public Rigidbody projectile;

    //////private ProjectileShootTriggerable launcher;

    //void OnInspectorGUI()
    //{
    //    var Actor_Scale = Target as Actor_Scale;
    //}

    public override void Initialize(GameObject obj)
    {
        //////launcher = obj.GetComponent<ProjectileShootTriggerable>();
        //////launcher.projectileForce = projectileForce;
        //////launcher.projectile = projectile;
    }

    public override void TriggerAbility()
    {
        //////launcher.Launch();
    }


}
//[CustomEditor(typeof(Actor_Scale)]
//public class Editor_ActorScale : Editor
//{

//}
//[custom]
