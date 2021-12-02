using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class Player : MonoBehaviour
{
    float speed = 100;

    Rigidbody2D rb;

    public GameObject bulletPrefab;

    public static bool Alive { get => (whiteboard.instance.player != null); }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        whiteboard.instance.player = this;
    }

    void Update()
    {
        Move();
    }

    void Move()
	{
        //Vector2 move = Vector2.zero;
        //if (Input.GetKey(KeyCode.W)) move += Vector2.up;
        //if (Input.GetKey(KeyCode.S)) move += Vector2.down;
        //if (Input.GetKey(KeyCode.A)) move += Vector2.left;
        //if (Input.GetKey(KeyCode.D)) move += Vector2.right;
        //if (move == Vector2.zero) return;
        //rb.velocity = move.normalized * speed * Time.deltaTime;
    }
}
