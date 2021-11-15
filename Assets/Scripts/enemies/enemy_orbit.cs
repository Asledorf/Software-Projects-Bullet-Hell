using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_orbit : enemy
{
	
	Transform objectToOrbit; //Object To Orbit
	Vector3 orbitAxis = Vector3.forward; //Which vector to use for Orbit

	[Space(5)]
	public float orbitRadius = 75; //Orbit Radius
	public float orbitRadiusCorrectionSpeed = .5f; //How quickly the object moves to new position
	public float orbitRoationSpeed = 10; //Speed Of Rotation arround object
	public float orbitAlignToDirectionSpeed = .5f; //Realign speed to direction of travel

	private Vector3 orbitDesiredPosition;

	private void Start()
	{
		orbitDesiredPosition = whiteboard.instance.player.transform.position;
		objectToOrbit = whiteboard.instance.player.transform;
	}

	void Update()
    {
        if (!CheckForPlayer()) return;
        Move();
        Shoot();
    }

	public override void Move()
	{
		transform.RotateAround(objectToOrbit.position, orbitAxis, orbitRoationSpeed * Time.deltaTime);
		orbitDesiredPosition = (transform.position - objectToOrbit.position).normalized * orbitRadius + objectToOrbit.position;
		transform.position = Vector3.Slerp(transform.position, orbitDesiredPosition, Time.deltaTime * orbitRadiusCorrectionSpeed);

		transform.up = (transform.position - objectToOrbit.position).normalized;
	}

	public override void OnTriggerEnter2D(Collider2D collision)
	{

	}

	public override void Shoot()
	{

	}
}
