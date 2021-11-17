using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ep_homing : e_projectile
{
	protected override void pattern()
	{
        Vector3 direction = (Player.position - transform.position).normalized;
        transform.up = direction;
        transform.position += direction * move_speed * Time.deltaTime;
	}
}
