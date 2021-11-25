using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPickup : Powerup
{
    public override void PowerupEffect(GameObject target)
    {
        if(target.TryGetComponent(out TripleShot tripleShot))
        {
            tripleShot.enabled = true;
        }
        else
        {
            (target.AddComponent(typeof(TripleShot)) as TripleShot).enabled = true;
        }
    }
}
