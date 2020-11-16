using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int baseHealth = 3;
    [SerializeField]
    private float transformRechargeRate = 3f;
    [SerializeField]
    private float transformDepleteRate = 15f;
    [SerializeField]
    private float transformDepleteOnHit = 15f;

    public float TransformPercentage = 0f;
    public bool HasTransformAbility = false;
    public bool isTransformed = false;

    // Objectives
    public bool[] objectives = new bool[3];
    

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
        // Update the status of the transform ability
        if (HasTransformAbility)
        {
            if (!isTransformed) 
            { 
                if (TransformPercentage < 100f)
                {
                    // Increase transform percentage
                    TransformPercentage += transformRechargeRate * Time.deltaTime;
                }
                else if(TransformPercentage > 100f)
                {
                    TransformPercentage = 100f;
                    Debug.Log("Transform Ready");
                }
            }
            else
            {
                if (TransformPercentage <= 0f)
                {
                    // Change back to ranged mode when running out of transform percentage
                    isTransformed = false;
                    TransformPercentage = 0f;
                    GetComponent<PlayerWeaponController>().isInRangedMode = true;
                }
                else
                {
                    // Reduce transform percentag while in the transformed state
                    TransformPercentage -= transformDepleteRate * Time.deltaTime;
                }
            }
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int damage)
    {
        if (!isTransformed)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
        else
        {
            TransformPercentage -= transformDepleteOnHit;
        }
    }
    // Everything that needs to happen when the player dies
    public void Die()
    {
        Debug.Log("Player has died");
    }
}
