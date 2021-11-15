using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_beeline : enemy
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
		Vector3 direction = go.transform.position - transform.position;
		transform.position += direction.normalized * approach_speed * Time.deltaTime;
	}

	public override void Shoot()
	{
		
	}
}
