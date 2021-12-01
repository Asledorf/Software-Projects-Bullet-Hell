using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ep_fast : e_projectile
{
	private void Update() => base.Update();

	private Vector3 targetpos;
	private Vector3 direction;

	private void Start()
	{
		targetpos = whiteboard.instance.player.transform.position;
		direction = (targetpos - transform.position).normalized;
		Destroy(gameObject, 10);
	}

	protected override void pattern()
	{
		transform.position += direction * move_speed * Time.deltaTime;
	}
}
