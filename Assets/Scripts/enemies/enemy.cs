using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemy : MonoBehaviour
{
	public e_shoot shoot_script;
	public float approach_speed = 100f;
	public float lateral_speed = .5f;

	public float firerate = .2f;

	public abstract void OnTriggerEnter2D(Collider2D collision);
	public abstract void Move();
	public abstract void Shoot();

	public bool CheckForPlayer() 
	{
		bool condition = whiteboard.instance.player;
		if (!condition) Destroy(gameObject);
		return condition;
	}
}