using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinwheel : Powerup
{
    public float shoot_speed = 100;
    public GameObject bullet_prefab;
    public float fire_rate = 0.5f;
    float accumulator = 0;

    public float lifeTime = 5f;
    private float timer = 0;

    private void OnEnable()
    {
        timer = 0;
        gameObject.GetComponent<Gun>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((accumulator += Time.deltaTime) >= fire_rate)
        {
            Shoot();
            accumulator = 0;
        }
        if((timer += Time.deltaTime) >= lifeTime)
        {
            gameObject.GetComponent<Gun>().enabled = true;
            this.enabled = false;
        }
    }

    void Shoot()
    {
        Vector3 shoot_direction = whiteboard.instance.rightJoystick.Direction;
        if (bullet_prefab && shoot_direction != Vector3.zero)
        {
            //make bullets
            GameObject up = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            GameObject down = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            GameObject leftUp = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            GameObject rightUp = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            GameObject leftDown = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            GameObject rightDown = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);

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
    }

    public override void PowerupEffect(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}
