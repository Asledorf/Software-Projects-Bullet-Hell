using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance { get => instance; }
    private static PowerUpManager instance;

    public List<GameObject> powerups = new List<GameObject>();

    public float DropRate;

    public List<float> chances = new List<float>();

    public void Start()
    {
        instance = this;
    }

    public void SpawnPowerUp(Vector3 position)
    {
        float roll = Random.Range(0, 1);

        if(roll <= DropRate)
        {
            float totalChance = 0;
            roll = Random.Range(0, 1);
            for(int i = 0; i < chances.Count; i++)
            {
                totalChance += chances[i];
                if(roll < totalChance)
                {
                    Instantiate(powerups[i], position, Quaternion.identity);
                    return;
                }
            }
        }
    }
}
