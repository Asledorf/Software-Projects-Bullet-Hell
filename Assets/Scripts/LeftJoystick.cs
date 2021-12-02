using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftJoystick : MonoBehaviour
{
    public Joystick joystick;
    float speed = 10f;

    Rigidbody2D rb;

	private void Start()
	{
        rb = GetComponent<Rigidbody2D>();
        joystick = whiteboard.instance.leftJoystick;
    }

	void Update()
    {
        rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
        transform.up = rb.velocity;
    }
}
