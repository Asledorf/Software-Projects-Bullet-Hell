using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_stationary : enemy
{
	void Update() => base.Update();
	void Start()
	{
		base.Start();
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
		if ((dt_accumulator += Time.deltaTime) >= fire_rate)
		{
			dt_accumulator = 0;
			shoot_script.Shoot();
		}
	}
}
