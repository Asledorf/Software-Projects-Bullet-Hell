using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : BasicShoot
{
    public float shoot_speed = 100;

    RightJoystick joystick;

    public float lifeTime = 5f;
    private float timer = 0;

    public void Awake()
    {
        joystick = GetComponent<RightJoystick>();
        fire_rate = 0.05f;
    }

    public void OnEnable()
    {
        if(joystick == null) joystick = GetComponent<RightJoystick>();
        if (joystick.shotType != null) joystick.shotType.enabled = false;

        joystick.shotType = this;
        joystick.fire_rate = fire_rate;
    }

    private void Update()
    {
        if((timer += Time.deltaTime) >= lifeTime)
        {
            GetComponent<Gun>().enabled = true;
            this.enabled = false;
        }
    }

    public override bool Shoot(Vector2 direction, GameObject bullet)
    {
        if (direction != Vector2.zero & bullet)
        {
            GameObject go = Instantiate(bullet, transform.position, Quaternion.identity, null);
            go.GetComponent<bullet>().move = direction.normalized * shoot_speed;
            Destroy(go, 3);
        }
        return false;
    }

    private void OnDisable()
    {
        timer = 0;
    }
}
