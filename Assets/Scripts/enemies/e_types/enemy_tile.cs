using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_tile : enemy
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
		Vector3 player_position = whiteboard.instance.player.transform.position;
		Vector3 this_position = transform.position;
		float delta_x = player_position.x - this_position.x;
		float delta_y = player_position.y - this_position.y;
		Vector3 move = Vector3.zero;
		//choose direction to move
		if(Mathf.Abs(delta_x) > Mathf.Abs(delta_y)) //move in x
			if(delta_x > 0)	move = Vector3.right;
			else			move = Vector3.left;
		else //move in y
			if(delta_y > 0)	move = Vector3.up;
			else			move = Vector3.down;
		transform.position += move * approach_speed * Time.deltaTime;
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
