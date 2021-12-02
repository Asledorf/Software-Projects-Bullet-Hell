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

    private void Start()
    {
        joystick = whiteboard.instance.rightJoystick;
    }

    void Update()
    {
        if ((accumulator += Time.deltaTime) >= fire_rate)
        {
            Shoot();
            accumulator = 0;
        }
    }

    void Shoot()
    {
        Vector2 shoot_direction = new Vector2(joystick.Horizontal, joystick.Vertical);

        if (shoot_direction != Vector2.zero & bullet_prefab)
        {
            GameObject go = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            go.GetComponent<bullet>().move = shoot_direction.normalized * shoot_speed;
            Destroy(go, 3);
        }
    }
}
