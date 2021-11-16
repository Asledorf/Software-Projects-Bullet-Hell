using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class e_shoot : MonoBehaviour
{
	public e_projectile[] bullet_options;
	public float fire_rate;
	protected float dt_accumulator;
	protected Player player;
	protected void Start()
	{
		player = whiteboard.instance.player;
		if (!player) Destroy(gameObject);
	}
	protected abstract void Shoot();
	protected void Update()
	{
		if (!player) return;
	}
}
