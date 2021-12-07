using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicShoot : MonoBehaviour
{
    public float fire_rate;

    public abstract bool Shoot(Vector2 direction, GameObject bullet);
}
