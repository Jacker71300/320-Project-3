using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int baseHealth = 3;

    // Everything objective and inventory related

    public void Init()
    {
        health = baseHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    // Everything that needs to happen when the player dies
    public void Die()
    {

    }
}
