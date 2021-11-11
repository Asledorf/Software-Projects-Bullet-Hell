using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
	
	public float move_speed = 0.5f;
	private void Update()
	{
		Player go = FindObjectOfType<Player>();
		Vector3 direction = go.transform.position - transform.position;
		transform.position += direction.normalized * move_speed * Time.deltaTime;
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.LogError("FUCK AAAAA");
		if (collision.gameObject.CompareTag("bad"))
		{
			Destroy(collision.gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.LogError("FUCK AAAAA");
		if (collision.gameObject.CompareTag("bad"))
		{
			Destroy(collision.gameObject);
		}
	}
}
