using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Powerup : MonoBehaviour
{
    public virtual void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PowerupEffect(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    public abstract void PowerupEffect(GameObject target);
}
