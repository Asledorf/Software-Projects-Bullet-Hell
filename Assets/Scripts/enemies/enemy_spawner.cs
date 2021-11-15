using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    public GameObject[] enemies;

    [Space(10)]
    [Header("Where to spawn")]
    public float x_min = 0;
    public float x_max = 0;
    public float y_min = 0;
    public float y_max = 0;

    [Space(5)]
    [Header("When to spawn")]
    public float min_spawn_time = 0;
    public float max_spawn_time = 10;

    [Space(5)]
    [Header("How many to spawn")]
    public float min_spawn_amount = 0;
    public float max_spawn_amount = 10;

    //privates not shown in inspector
    private float time_accumulator = 0;
    private float current_spawn_delay = 0;

	private void Start()
	{
        current_spawn_delay = Random.Range(min_spawn_time, max_spawn_time);
	}
	
	void Update()
    {
        time_accumulator += Time.deltaTime;
        if (time_accumulator > current_spawn_delay)
		{
			//spawn random enemy
			for (int i = 0; i < Random.Range(min_spawn_amount, max_spawn_amount); i++)
			{
                Vector3 position = Vector3.zero;
                position.x = Random.Range(x_min,x_max);
                position.y = Random.Range(y_min,y_max);
                Instantiate(enemies[(int)Random.Range(0,enemies.Length)], position, Quaternion.identity);
			}
            //set time accumulator to 0
            time_accumulator = 0;
            //reset random delay
            current_spawn_delay = Random.Range(min_spawn_time, max_spawn_time);
        }
    }
}
