using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance { get => instance; }
    private static RespawnManager instance;

    public Transform spawnLocation;

    public int lives = 3;

    [SerializeField]
    GameObject player;

    private RespawnManager() { }

    bool respawning = false;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (whiteboard.instance.player == null && lives > 0 && !respawning)
        {
            StartCoroutine(Respawn());
        }
        else if(lives <= 0)
        {
            //GameOver
        }
    }

    public IEnumerator Respawn()
    {
        respawning = true;
        yield return new WaitForSeconds(1);

        Instantiate(player, spawnLocation.position, spawnLocation.rotation);
        lives--;
        respawning = false;
    }
}
