using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_stationary : enemy
{
	private void Update()
	{
		if (!CheckForPlayer()) return;
		Move();
		Shoot();
	}

	public override void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
			Destroy(collision.gameObject);
	}

	public override void Move()
	{
		Player go = whiteboard.instance.player;
		if (!go) return;
	}

	public override void Shoot()
	{

	}
}
