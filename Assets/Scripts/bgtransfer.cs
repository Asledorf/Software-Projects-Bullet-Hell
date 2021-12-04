using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgtransfer : MonoBehaviour
{
    public Transform cam;
    public float x;
    public float y;
    public float z = -10;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            cam.position = new Vector3(x, y, z);
        }
    }
}
