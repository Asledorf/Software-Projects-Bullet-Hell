using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_tile : enemy
{
	void Update()
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
		Vector3 player_position = whiteboard.instance.player.transform.position;
		Vector3 this_position = transform.position;
		float delta_x = player_position.x - this_position.x;
		float delta_y = player_position.y - this_position.y;
		if(Mathf.Abs(delta_x) > Mathf.Abs(delta_y))
		{ //move in x
			if(delta_x > 0)
			{
				transform.position += Vector3.right * approach_speed * Time.deltaTime;

			}
			else //< 0
			{
				transform.position += Vector3.left * approach_speed * Time.deltaTime;
			}
		}
		else
		{ //move in y
			if (delta_y > 0)
			{
				transform.position += Vector3.up * approach_speed * Time.deltaTime;

			}
			else //< 0
			{
				transform.position += Vector3.down * approach_speed * Time.deltaTime;
			}
		}
	}

	public override void Shoot()
	{

	}
}
