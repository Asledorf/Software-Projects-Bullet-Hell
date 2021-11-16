using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class es_basic : e_shoot
{
	protected override void Shoot()
	{
		Instantiate(bullet_options[0]);
	}

	// Update is called once per frame
	void Update()
    {
        base.Update();
		if ((dt_accumulator += Time.deltaTime) >= fire_rate)
		{
			dt_accumulator = 0;
			Shoot();
		}
    }
	
}
