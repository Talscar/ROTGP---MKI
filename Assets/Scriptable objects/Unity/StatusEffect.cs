using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Abilities/StatusEffects/Actor Scale")]
public class StatusEffect : Ability {

    //What abilitys will this have as Data structs
    //enum to select any one of these Data structs and utilise the variables within. Locked based on the selection of the Enum we will have.
    public struct fatness
    {

    }

    public bool hasScaleAlteration = false;
    [Tooltip("1 is equal to 100%. So 0 is equal to 0% and 2 = 200%. \n This value sets the current scale of something by a percentage.")]
    [Range(0f, 2f)]
    public float scalePercent = 1f;

    //Case statement and Enums to control what is shown and what is processed. Less than, Greater than and Equal too.

    //bool hasSpeedAlteration = false;
    //[Tooltip("1 is equal to 100%. So 0 is equal to 0% and 15 = 1500%. \n This value sets the current speed of something by a percentage." )]
    //[Range(0f, 15f)]
    //public float speedPercent = 1f;




    [Header("Global values ")]
    [Tooltip("If duration it lasts over time, else it will only run once.")]
    public bool hasDuration = false;
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


[CustomEditor(typeof(StatusEffect))]
//[ca]
public class Editor_ActorScale : Editor
{
    SerializedProperty abilityName;
    SerializedProperty abilitySprite;
    SerializedProperty abilitySound;
    SerializedProperty abilityBaseCoolDown;

    //
    SerializedProperty Actor_Scale;
    SerializedProperty hasScaleAlteration;// = false;
    SerializedProperty scalePercent;

    SerializedProperty hasDuration;
    SerializedProperty duration;


    public void OnEnable()
    {
        abilityName = serializedObject.FindProperty("abilityName");
        abilitySprite = serializedObject.FindProperty("abilitySprite");
        abilitySound = serializedObject.FindProperty("abilitySound");
        abilityBaseCoolDown = serializedObject.FindProperty("abilityBaseCoolDown");


        Actor_Scale = serializedObject.FindProperty("Actor_Scale");
        hasScaleAlteration = serializedObject.FindProperty("hasScaleAlteration");
        hasDuration = serializedObject.FindProperty("hasDuration");
        scalePercent = serializedObject.FindProperty("scalePercent");
        duration = serializedObject.FindProperty("duration");
        //lookAtPoint = serializedObject.FindProperty("lookAtPoint");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //[Header("")]

        EditorGUILayout.PropertyField(abilityName);
        EditorGUILayout.PropertyField(abilitySprite);
        EditorGUILayout.PropertyField(abilitySound);
        EditorGUILayout.PropertyField(abilityBaseCoolDown);
        EditorGUILayout.Separator();

        Debug.LogWarning("Any modifications to script will have to be added upon requiring modification!");
        EditorGUILayout.PropertyField(hasScaleAlteration);
        if(hasScaleAlteration.boolValue)
        {
                    EditorGUILayout.PropertyField(scalePercent);
        }
        EditorGUILayout.PropertyField(hasDuration);
        if(hasDuration.boolValue)
        {
            EditorGUILayout.PropertyField(duration);
        }

        //EditorGUILayout.PropertyField(Actor_Scale);

        //if(Actor_Scale.floatValue.)
        //if (lookAtPoint.vector3Value.y > (target as LookAtPoint).transform.position.y)
        //{
        //    EditorGUILayout.LabelField("(Above this object)");
        //}
        //EditorGUILayout.FloatField(Actor_Scale.)


        serializedObject.ApplyModifiedProperties();
    }
}
//[custom]
