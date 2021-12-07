using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightJoystick : MonoBehaviour
{
    public Joystick joystick;

    public float shoot_speed = 100;
    public GameObject bullet_prefab = null;
    public float fire_rate = 0.1f;
    float accumulator = 0;

    public BasicShoot shotType = null;

    [HideInInspector]
    public bool shooting = false;

    private void Start()
    {
        joystick = whiteboard.instance.rightJoystick;
    }

    void Update()
    {
        if (!shooting)
        {
            if ((accumulator += Time.deltaTime) >= fire_rate)
            {
                Vector2 shoot_direction = new Vector2(joystick.Horizontal, joystick.Vertical);

                if(shoot_direction != Vector2.zero)
                {
                    shooting = shotType.Shoot(shoot_direction, bullet_prefab);
                    accumulator = 0;
                }
            }
        }
    }
}
