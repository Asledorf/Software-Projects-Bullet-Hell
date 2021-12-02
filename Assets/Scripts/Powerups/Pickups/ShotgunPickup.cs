using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : Powerup
{
    public override void PowerupEffect(GameObject target)
    {
        if (!target.TryGetComponent(out Gun gun) || !gun.enabled) return;

        if (target.TryGetComponent(out Shotgun shotgun))
        {
            shotgun.enabled = true;
        }
        else
        {
            (target.AddComponent(typeof(Shotgun)) as Shotgun).enabled = true;
        }

        Destroy(gameObject);
    }
}
