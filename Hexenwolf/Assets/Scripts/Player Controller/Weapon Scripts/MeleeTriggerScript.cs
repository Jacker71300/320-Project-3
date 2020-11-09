using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTriggerScript : MonoBehaviour
{
    [SerializeField] float damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Damageable":
                // Do damage to other object then destroy this bullet
                break;
            case "Breakable":
                // Break the other object then destroy this bullet
                other.gameObject.GetComponent<BreakableObjectScript>().GetHit(damage);
                break;
            case "Player":
                // Check to see if the projectile was shot by the player before doing damage
                break;
            case "Bullet":
                // Do nothing so bullets don't break when hitting each other
                break;
            default:
                // Do nothing so the claws just disappear
                break;

        }
    }
}
