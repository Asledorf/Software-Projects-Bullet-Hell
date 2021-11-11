using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float shoot_speed = 100;
    public GameObject bullet_prefab = null;
    public float fire_rate = 0.1f;
    float accumulator = 0;
    // Update is called once per frame
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
        Vector3 shoot_direction = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow)) shoot_direction += Vector3.up;
        if (Input.GetKey(KeyCode.DownArrow)) shoot_direction += Vector3.down;
        if (Input.GetKey(KeyCode.LeftArrow)) shoot_direction += Vector3.left;
        if (Input.GetKey(KeyCode.RightArrow)) shoot_direction += Vector3.right;

        if (shoot_direction != Vector3.zero & bullet_prefab)
        {
            GameObject go = Instantiate(bullet_prefab, transform.position, Quaternion.identity, null);
            go.GetComponent<bullet>().move = shoot_direction.normalized * shoot_speed;
            Destroy(go, 3);
        }
    }
}