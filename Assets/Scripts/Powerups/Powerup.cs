using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Powerup : MonoBehaviour
{
    public float lifetime;
    private float timer = 0;

    public virtual void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void Update()
    {
        if((timer += Time.deltaTime) >= lifetime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PowerupEffect(collision.gameObject);
        }
    }

    public abstract void PowerupEffect(GameObject target);
}
