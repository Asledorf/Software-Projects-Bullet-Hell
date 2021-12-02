using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : MonoBehaviour
{
    public float shoot_speed = 100;
    public GameObject bullet_prefab;
    float fire_rate = 0.05f;
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
        if ((timer += Time.deltaTime) >= lifeTime)
        {
            gameObject.GetComponent<Gun>().enabled = true;
            this.enabled = false;
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
