using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int dmgPerHit;


    private void Awake()
    {
        health = 100;
    }


    private void Update()
    {
        if(health <= 0)
        {
            Debug.Log("DEAD");
        }
    }
        

    public void Hit()
    {
        health -= dmgPerHit;
    }
}
