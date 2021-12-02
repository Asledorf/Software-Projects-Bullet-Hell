using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_BlackHole : Boss
{
	public override void OnHit()
	{
		Health -= 1;
		if (Health <= 0) 
		{
			Destroy(gameObject);
			return;
		}

		HealthBar.SetHealthBar(Health, MaxHealth);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<bullet>()) OnHit();
		Destroy(collision.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<bullet>()) OnHit();
		Destroy(collision.gameObject);
	}

	// Start is called before the first frame update
	void Start()
    {
		GameObject go = Instantiate(HealthBarPrefab, FindObjectOfType<BossManager>().transform);
		HealthBar = go.GetComponent<HealthBar>();
		HealthBar.SetText(Name);
		HealthBar.SetHealthBar(Health, MaxHealth);
    }

	private void OnDestroy()
	{
		if (HealthBar) Destroy(HealthBar.gameObject);
	}
}
