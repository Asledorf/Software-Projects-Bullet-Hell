using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bullets themselves handle their individual movement logic
public abstract class e_projectile : MonoBehaviour
{
    public float move_speed = 15;
    protected abstract void pattern();
    // Start is called before the first frame update

    // Update is called once per frame
    protected void Update()
    {
        if(!whiteboard.instance.player)
		{
            Destroy(gameObject);
            return;
		}
        pattern(); 
    }
}
