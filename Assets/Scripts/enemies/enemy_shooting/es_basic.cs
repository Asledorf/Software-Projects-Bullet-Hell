using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class es_basic : e_shoot
{
	private void Start()
	{
		base.Start();
		Shoot();
	}

	public override void Shoot()
	{
		Instantiate(bullet_options[0], transform.position, Quaternion.identity);
		//Instantiate(bullet_options[0]);
	}

	// Update is called once per frame
	void Update()
    {
        base.Update();
    }
	
}
