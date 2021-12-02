using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    public float MaxHealth = 0;
    public float Health = 0;
    public string Name = "";
    [HideInInspector]
    protected HealthBar HealthBar;
    public GameObject HealthBarPrefab;

    public abstract void OnHit();
}
