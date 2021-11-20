using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float shoot_speed = 100;
    public GameObject bullet_prefab = null;
    float fire_rate = 0.3f;
    float accumulator = 0;
    // Update is called once per frame
    void Update()
    {
        if ((accumulator += Time.deltaTime) >= fire_rate && bullet_prefab)
        {
            Shoot();
            accumulator = 0;
        }
    }

    void Shoot()
    {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Up();
            GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            left.GetComponent<bullet>().move = (Vector3.left + Vector3.up + Vector3.up).normalized * shoot_speed;
            Destroy(left, 3);
            GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            right.GetComponent<bullet>().move = (Vector3.right + Vector3.up + Vector3.up).normalized * shoot_speed;
            Destroy(right, 3);
        }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Down();
            GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            left.GetComponent<bullet>().move = (Vector3.left + Vector3.down + Vector3.down).normalized * shoot_speed;
            Destroy(left, 3);
            GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            right.GetComponent<bullet>().move = (Vector3.right + Vector3.down + Vector3.down).normalized * shoot_speed;
            Destroy(right, 3);
        }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Right();
            GameObject up = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            up.GetComponent<bullet>().move = (Vector3.right + Vector3.up + Vector3.up).normalized * shoot_speed;
            Destroy(up, 3);
            GameObject down = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            down.GetComponent<bullet>().move = (Vector3.right + Vector3.down + Vector3.down).normalized * shoot_speed;
            Destroy(down, 3);
        }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Left();
            GameObject up = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            up.GetComponent<bullet>().move = (Vector3.left + Vector3.up + Vector3.up).normalized * shoot_speed;
            Destroy(up, 3);
            GameObject down = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            down.GetComponent<bullet>().move = (Vector3.left + Vector3.down + Vector3.down).normalized * shoot_speed;
            Destroy(down, 3);
        }
    }

    void Up()
    {
            GameObject up = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            up.GetComponent<bullet>().move = Vector3.up.normalized * shoot_speed;
            Destroy(up, 3);
    }

    void Down()
    {
            GameObject down = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            down.GetComponent<bullet>().move = Vector3.down.normalized * shoot_speed;
            Destroy(down, 3);
    }

    void Right()
    {
            GameObject right = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            right.GetComponent<bullet>().move = Vector3.right.normalized * shoot_speed;
            Destroy(right, 3);
    }

    void Left()
    {
            GameObject left = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            left.GetComponent<bullet>().move = Vector3.left.normalized * shoot_speed;
            Destroy(left, 3);
    }
}
