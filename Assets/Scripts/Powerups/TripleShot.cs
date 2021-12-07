using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : BasicShoot
{
    public float shoot_speed = 200;

    float waitTime = 0.08f;
    float waitTimer = 0;
    int shots = 0;

    public float lifeTime = 5f;
    private float timer = 0;

    bool shooting = false;

    public RightJoystick joystick;

    private Vector2 shoot_direction;
    private GameObject bullet;

    public void Awake()
    {
        joystick = GetComponent<RightJoystick>();
        fire_rate = 0.25f;
    }

    public void OnEnable()
    {
        if (joystick == null) joystick = GetComponent<RightJoystick>();
        if (joystick.shotType != null) joystick.shotType.enabled = false;

        joystick.shotType = this;
        joystick.fire_rate = fire_rate;
    }

    private void Update()
    {
        if (shooting)
        {
            if ((waitTimer += Time.deltaTime) >= waitTime)
            {
                GameObject go = Instantiate(bullet, transform.position, Quaternion.identity, null);
                go.GetComponent<bullet>().move = shoot_direction.normalized * shoot_speed;
                Destroy(go, 3);
                waitTimer = 0;
                if(shots++ == 2)
                {
                    shooting = false;
                    shots = 0;

                    joystick.shooting = shooting;
                }
                
            }
        }

        if ((timer += Time.deltaTime) >= lifeTime)
        {
            GetComponent<Gun>().enabled = true;
            this.enabled = false;
        }
    }

    public override bool Shoot(Vector2 direction, GameObject bullet)
    {
        if (!shooting)
        {
            if (direction != Vector2.zero && bullet)
            {
                shoot_direction = direction;
                this.bullet = bullet;
                shooting = true;
            }
        }

        return shooting;
    }

    private void OnDisable()
    {
        timer = 0;
        shots = 0;
        waitTimer = 0;
    }
}
