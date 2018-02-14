using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/StatusEffect")]
public class StatusEffect : Ability {
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
