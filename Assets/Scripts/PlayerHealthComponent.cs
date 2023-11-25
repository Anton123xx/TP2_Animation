using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
            SceneManager.LoadScene(2);
           
        }
    }

    public void Hit()
    {
        health -= dmgPerHit;
    }
}
