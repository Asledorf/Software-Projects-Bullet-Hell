using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance { get => instance; }
    private static RespawnManager instance;

    public bool playerAlive = false;

    private RespawnManager() { }

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        
    }
}
