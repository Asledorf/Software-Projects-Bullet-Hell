using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinwheel : BasicShoot
{
    public float shoot_speed = 100;

    RightJoystick joystick;

    public float lifeTime = 5f;
    private float timer = 0;

    public void Awake()
    {
        joystick = GetComponent<RightJoystick>();
        fire_rate = 0.2f;
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
        if ((timer += Time.deltaTime) >= lifeTime)
        {
            GetComponent<Gun>().enabled = true;
            this.enabled = false;
        }
    }

    public override bool Shoot(Vector2 direction, GameObject bullet)
    {
        Vector3 shoot_direction = whiteboard.instance.rightJoystick.Direction;
        if (bullet && shoot_direction != Vector3.zero)
        {
            //make bullets
            GameObject up = Instantiate(bullet, transform.position, Quaternion.identity, null);
            GameObject down = Instantiate(bullet, transform.position, Quaternion.identity, null);
            GameObject left = Instantiate(bullet, transform.position, Quaternion.identity, null);
            GameObject right = Instantiate(bullet, transform.position, Quaternion.identity, null);
            GameObject leftUp = Instantiate(bullet, transform.position, Quaternion.identity, null);
            GameObject rightUp = Instantiate(bullet, transform.position, Quaternion.identity, null);
            GameObject leftDown = Instantiate(bullet, transform.position, Quaternion.identity, null);
            GameObject rightDown = Instantiate(bullet, transform.position, Quaternion.identity, null);

            //move bullets
            up.GetComponent<bullet>().move = Vector3.up.normalized * shoot_speed;
            down.GetComponent<bullet>().move = Vector3.down.normalized * shoot_speed;
            left.GetComponent<bullet>().move = Vector3.left.normalized * shoot_speed;
            right.GetComponent<bullet>().move = Vector3.right.normalized * shoot_speed;
            leftUp.GetComponent<bullet>().move = (Vector3.left + Vector3.up).normalized * shoot_speed;
            rightUp.GetComponent<bullet>().move = (Vector3.right + Vector3.up).normalized * shoot_speed;
            leftDown.GetComponent<bullet>().move = (Vector3.left + Vector3.down).normalized * shoot_speed;
            rightDown.GetComponent<bullet>().move = (Vector3.right + Vector3.down).normalized * shoot_speed;

            //destroy bullets
            Destroy(up, 3);
            Destroy(down, 3);
            Destroy(left, 3);
            Destroy(right, 3);
            Destroy(leftUp, 3);
            Destroy(rightUp, 3);
            Destroy(leftDown, 3);
            Destroy(rightDown, 3);
        }
        return false;
    }

    private void OnDisable()
    {
        timer = 0;
    }
}
