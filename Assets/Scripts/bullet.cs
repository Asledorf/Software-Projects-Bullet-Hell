using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 move = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.position += move * Time.deltaTime;
    }

	private void OnCollisionEnter(Collision collision)
	{
		Debug.LogError("FUCK");
		if (collision.gameObject.CompareTag("bad"))
		{
			Destroy(collision.gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.LogError("FUCK");
		if(collision.gameObject.CompareTag("bad"))
		{
			Destroy(collision.gameObject);
		}
	}
}