using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinwheelPickup : Powerup
{
    public override void PowerupEffect(GameObject target)
    {
        if(target.TryGetComponent(out Pinwheel pinwheel))
        {
            pinwheel.enabled = true;
            target.GetComponent<Gun>().enabled = false;
        }
    }
}
