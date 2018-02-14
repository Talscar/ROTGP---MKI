using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/StatusEffect")]
public class StatusEffect : Ability {


    //I want a drop menu that selects a specific set of abilitys.
    //I want to then have in the inspector a way to select an ability with variables specific to it's type.
    //Then I want to be able to set these variables via a single script process using either a struct or other process!
    //From there, I want the script that uses this derived from Mono behavior to then process the effects either been inflicted on self or inflicted on another!









    [Header("Status effects")]
    public float fatness = 0.01f;
    public float speed = 0.99f;
    //public float projectileForce = 500f;
    //public Rigidbody projectile;

    //private ProjectileShootTriggerable launcher;
    private movementController player;

    public override void Initialize(GameObject obj)
    {
        player = obj.GetComponent<movementController>();

        //launcher = obj.GetComponent<ProjectileShootTriggerable>();
        //launcher.projectileForce = projectileForce;
        //launcher.projectile = projectile;
    }

    public override void TriggerAbility()
    {
        player.statusProcessor(this);
        //launcher.Launch();
    }
}
