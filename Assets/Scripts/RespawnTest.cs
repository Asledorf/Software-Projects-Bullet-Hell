using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTest : MonoBehaviour
{
    public GameObject extraLife;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) Destroy(whiteboard.instance.player.gameObject);
        if (Input.GetMouseButtonDown(3)) Instantiate(extraLife, new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.identity);
    }
}
