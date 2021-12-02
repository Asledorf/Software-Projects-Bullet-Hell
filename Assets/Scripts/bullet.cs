using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	[HideInInspector]
    public Vector3 move = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.position += move * Time.deltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("bad"))
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
