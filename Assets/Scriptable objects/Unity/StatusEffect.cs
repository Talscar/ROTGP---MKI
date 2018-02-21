using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Abilities/StatusEffects/Actor Scale")]
public class StatusEffect : Ability {

    //What abilitys will this have as Data structs
    //enum to select any one of these Data structs and utilise the variables within. Locked based on the selection of the Enum we will have.
    public enum dataTypes
    {scale, speed, knockback};
    public dataTypes Effect;// = dataTypes.scale; 


    public scale Scale = new scale();
    [System.Serializable]public struct scale
    {
        public bool hasScaleAlteration;// = false;
        [Tooltip("1 is equal to 100%. So 0 is equal to 0% and 2 = 200%. \n This value sets the current scale of something by a percentage.")]
        [Range(0f, 2f)]
        public float scalePercent;// = 1f;
    }

    public speed Speed = new speed();
    [System.Serializable] public struct speed
    {
        public bool hasSpeedAlteration;// = false;
        [Tooltip("1 is equal to 100%. So 0 is equal to 0% and 15 = 1500%. \n This value sets the current speed of something by a percentage.")]
        [Range(0f, 15f)]
        public float speedPercent; // = 1f;
    }

    public knockback Knockback = new knockback();
    [System.Serializable] public struct knockback
    {

    }



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
    //SerializedPropertyType dataType;
    StatusEffect script;// = (StatusEffect)target;
    SerializedProperty Effect; //ENUM

    SerializedProperty Scale; //STRUCT
    SerializedProperty Speed; //STRUCT
    SerializedProperty Knockback; //STRUCT


    SerializedProperty abilityName; //STRING
    SerializedProperty abilitySprite; //IMAGE
    SerializedProperty abilitySound; //SOUND
    SerializedProperty abilityBaseCoolDown; //INT or FLOAT ???

    //
    SerializedProperty hasScaleAlteration; //BOOLEAN
    SerializedProperty scalePercent; //FLOAT

    SerializedProperty hasSpeedAlteration;
    SerializedProperty speedPercent;

    SerializedProperty hasDuration; //BOOLEAN
    SerializedProperty duration; //FLOAT


    public void OnEnable()
    {

        //dataType = SerializedPropertyType.Enum;
        Effect = serializedObject.FindProperty("Effect");

        //Struct data types
        Scale = serializedObject.FindProperty("Scale");
            //
        hasScaleAlteration = Scale.FindPropertyRelative("hasScaleAlteration");
        scalePercent = Scale.FindPropertyRelative("scalePercent");
            //

        Speed = serializedObject.FindProperty("Speed");
        //
        hasSpeedAlteration = Speed.FindPropertyRelative("hasSpeedAlteration");
        speedPercent = Speed.FindPropertyRelative("speedPercent");
            //
        Knockback = serializedObject.FindProperty("Knockback");
            //

            //


        //Struct data types


        //Ability Object
        abilityName = serializedObject.FindProperty("abilityName");
        abilitySprite = serializedObject.FindProperty("abilitySprite");
        abilitySound = serializedObject.FindProperty("abilitySound");
        abilityBaseCoolDown = serializedObject.FindProperty("abilityBaseCoolDown");
        //Ability Object

        //Global variables
        hasDuration = serializedObject.FindProperty("hasDuration");

        duration = serializedObject.FindProperty("duration");
        //lookAtPoint = serializedObject.FindProperty("lookAtPoint");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        StatusEffect script = (StatusEffect)target;
        //[Header("")]

        EditorGUILayout.PropertyField(abilityName);
        EditorGUILayout.PropertyField(abilitySprite);
        EditorGUILayout.PropertyField(abilitySound);
        EditorGUILayout.PropertyField(abilityBaseCoolDown);
        EditorGUILayout.Separator();

        Debug.LogWarning("Any modifications to script will have to be added upon requiring modification!");

    //THE Effects and abilitys
    //Effect

    //Scale = EditorGUILayout.Foldout(Scale, hasScaleAlteration);
    //EditorGUILayout.Foldout(Scale)
    //if (Scale.boolValue)
    //script.type = (StatusEffect.dataTypes).Editor

    //https://answers.unity.com/questions/1085035/how-can-i-create-a-enum-like-as-component-light.html


        //SCALE
        EditorGUILayout.PropertyField(Effect);
        if (script.Effect == StatusEffect.dataTypes.scale)
        {
            EditorGUILayout.PropertyField(Scale); //This is broken and not a boolean value.
            if(Scale.isExpanded)
            {
                EditorGUILayout.PropertyField(hasScaleAlteration);
                if (hasScaleAlteration.boolValue)
                {
                    EditorGUILayout.PropertyField(scalePercent);
                }
            }
        } //SCALE
        else if(script.Effect == StatusEffect.dataTypes.speed)
        {//Speed
            EditorGUILayout.PropertyField(Speed); //This is broken and not a boolean value.
            if (Speed.isExpanded)
            {
                EditorGUILayout.PropertyField(hasSpeedAlteration);
                if (hasSpeedAlteration.boolValue)
                {
                    EditorGUILayout.PropertyField(speedPercent);
                }
            }
        }//Speed
        else if(script.Effect == StatusEffect.dataTypes.knockback)
        {//Knockback

        }//Knockback



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
