using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BasicShoot
{
	public float shoot_speed = 100;

	RightJoystick joystick;

    public void Awake()
    {
		joystick = GetComponent<RightJoystick>();
		if (joystick.shotType == null) joystick.shotType = this;

		fire_rate = 0.15f;
    }

    public void OnEnable()
    {
		if (joystick.shotType != null) joystick.shotType.enabled = false;

		joystick.shotType = this;
		joystick.fire_rate = fire_rate;
    }

	public override bool Shoot(Vector2 direction, GameObject bullet)
	{
		if (direction != Vector2.zero && bullet)	
		{
			GameObject go = Instantiate(bullet, transform.position, Quaternion.identity, null);
			go.GetComponent<bullet>().move = direction.normalized * shoot_speed;
			Destroy(go, 3);

		}
		return false;
	}
}
