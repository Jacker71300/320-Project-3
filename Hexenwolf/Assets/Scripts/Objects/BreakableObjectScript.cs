﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectScript : MonoBehaviour
{
    [SerializeField] Transform DroppedObject;
    [SerializeField] double Health;
    [SerializeField] Transform DestroyedObject;

    /// <summary>
    /// Handles when the object gets hit by something
    /// </summary>
    /// <param name="Damage">The amount of damage the attack did to the object</param>
    public void GetHit(double Damage)
    {
        Health -= Damage;
        if(Health <= 0.0f)
        {
            // Drop an item
            if(DroppedObject != null)
            {
                Instantiate(DroppedObject, this.transform.position, Quaternion.identity);
            }

            // Play animation
            if (DestroyedObject != null)
            {
                Instantiate(DestroyedObject, this.transform.position, Quaternion.identity);
            }

            // Destroy this game object
            Destroy(gameObject);
        }
    }
}
