using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class Player : MonoBehaviour
{
	public static bool Alive { get { return whiteboard.instance.player; } }
	public static Vector3 position { get { return whiteboard.instance.player.transform.position; } }
	public static Player _this { get { return whiteboard.instance.player; } }

	public int lives = 0;

	public float speed = 100;
	// Start is called before the first frame update
	void Start()
	{
		whiteboard.instance.player = this;
	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	void Move()
	{
		Vector3 move = Vector3.zero;
		if (Input.GetKey(KeyCode.W)) move += Vector3.up;
		if (Input.GetKey(KeyCode.S)) move += Vector3.down;
		if (Input.GetKey(KeyCode.A)) move += Vector3.left;
		if (Input.GetKey(KeyCode.D)) move += Vector3.right;
		transform.position += move.normalized * speed * Time.deltaTime;
		if (move.normalized != Vector3.zero) transform.up = move.normalized;
	}

	public void TryKill()
	{
		if (lives <= 0)
			Destroy(gameObject);
		else
			lives--;
		Debug.Log($"lives: {lives}");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<e_projectile>())
			TryKill();
	}
}
