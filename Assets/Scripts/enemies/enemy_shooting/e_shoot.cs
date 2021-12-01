using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class defines how, when, and where to spawn bullets
public abstract class e_shoot : MonoBehaviour
{
	public e_projectile[] bullet_options;
	public float fire_rate;
	protected float dt_accumulator;

	protected void Start()
	{
		if (!Player.Alive) Destroy(gameObject);
	}

	protected void Update()
	{
		if (!Player.Alive) return;
	}

	public abstract void Shoot();
}
