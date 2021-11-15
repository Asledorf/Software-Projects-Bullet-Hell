using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftJoystick : MonoBehaviour
{
    public Joystick joystick;
    float speed = 100f;

    void Update()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
    }
}
