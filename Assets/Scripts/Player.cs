using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class Player : MonoBehaviour
{
    float speed = 80;
    float max_speed = 80;

    Rigidbody2D rb;

    public GameObject bulletPrefab;

    public static Vector3 position { get { return whiteboard.instance.player.transform.position; } }
    public static bool Alive { get { return whiteboard.instance.player; } }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        whiteboard.instance.player = this;
    }

    void Update()
    {
        Move();
        ClampSpeed();
        Wrap();
    }

    void Move()
	{
        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) move += Vector3.up;
        if (Input.GetKey(KeyCode.S)) move += Vector3.down;
        if (Input.GetKey(KeyCode.A)) move += Vector3.left;
        if (Input.GetKey(KeyCode.D)) move += Vector3.right;
		transform.position += move.normalized * speed * Time.deltaTime;
        if (move == Vector3.zero) return;
        transform.up = move.normalized;
	}

    public void Wrap()
	{
        //implement screen wrapping
	}

    public void ClampSpeed()
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "bad") Destroy(gameObject);
	}

    public void Kill()
    {
        Destroy(gameObject);
    }
}
