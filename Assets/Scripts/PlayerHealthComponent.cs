using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealthComponent : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int dmgPerHit = 100;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(health <= 0)
        {
            Debug.Log("GAMEOVER");
        }
    }

    public void Hit()
    {
        health -= dmgPerHit;
    }
}
