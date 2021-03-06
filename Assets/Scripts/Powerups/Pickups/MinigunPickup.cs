using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunPickup : Powerup
{
    public override void PowerupEffect(GameObject target)
    {
        if (target.TryGetComponent(out Minigun minigun))
        {
            minigun.enabled = true;
        }
        else
        {
            target.AddComponent(typeof(Minigun));
            target.GetComponent<Minigun>().enabled = true;
        }

        Destroy(gameObject);
    }
}
