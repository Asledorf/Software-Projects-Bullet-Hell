using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ep_undirected : e_projectile
{
	private void Update() => base.Update();

	protected override void pattern()
	{
		transform.position += transform.up * move_speed * Time.deltaTime;
	}
}
