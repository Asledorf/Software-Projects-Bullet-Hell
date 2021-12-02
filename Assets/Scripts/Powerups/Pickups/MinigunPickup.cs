using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunPickup : Powerup
{
    public override void PowerupEffect(GameObject target)
    {
        if (!target.TryGetComponent(out Gun gun) || !gun.enabled) return;

        if (target.TryGetComponent(out Minigun minigun))
        {
            minigun.enabled = true;
        }
        else
        {
            (target.AddComponent(typeof(Minigun)) as Minigun).enabled = true;
        }

        Destroy(gameObject);
    }
}
