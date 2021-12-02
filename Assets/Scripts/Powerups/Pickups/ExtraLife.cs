using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : Powerup
{
    public override void PowerupEffect(GameObject target)
    {
        RespawnManager.Instance.lives++;
        Destroy(gameObject);
    }
}
