using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//todo add types
 //linear
 //hook

public abstract class enemy : MonoBehaviour
{
	public e_shoot shoot_script;
	public float approach_speed = 100f;
	public float lateral_speed = .5f;

	public float fire_rate = .2f;
	protected float dt_accumulator = 0;

	public abstract void OnTriggerEnter2D(Collider2D collision);
	public abstract void Move();
	public abstract void Shoot();

	protected void Start()
	{
	}

	protected void Update()
	{
		if(!Player.Alive)
		{
			Destroy(gameObject);
			return;
		}
		Move();
		Shoot();
	}
}