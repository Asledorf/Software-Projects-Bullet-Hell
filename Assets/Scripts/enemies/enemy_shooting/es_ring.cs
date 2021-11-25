using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class es_ring : e_shoot
{
	public int amount;
	public float radius;
	public float delta_raidus;
	public Vector3 initial_angle;
	public float delta_angle;
	public float delay;
	public bool clockwise = true;
	Vector3 _angle;

	public override void Shoot()
	{
		StartCoroutine(Spawn());
	}

	//private bool running = false;
	IEnumerator Spawn()
	{
		void _make_bullet()
		{
			e_projectile b = Instantiate(bullet_options[0], transform.position, Quaternion.identity);
			b.transform.position += _angle.normalized * radius;
			b.transform.up = _angle;
		}

		void _update_params()
		{
			radius += delta_raidus;
			//
			if (clockwise)
			_angle = Quaternion.AngleAxis( delta_angle, Vector3.up) * _angle;
			else
			_angle = Quaternion.AngleAxis(-delta_angle, Vector3.up) * _angle;
		}

		//if (running) yield break;
		//running = true;

		//make ring of bullets
		for (int i = 0; i < amount; i++)
		{
			yield return new WaitForSeconds(delay);
			_make_bullet();
			_update_params();
		}
		_angle = initial_angle;

		//running = false;
	}
}
