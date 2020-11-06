using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTriggerScript : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float lifeTime;
    float lifeTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTimeLeft >= 0)
        {
            lifeTimeLeft -= Time.deltaTime;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public void Attack()
    {
        //Make trigger active
        lifeTimeLeft = lifeTime;
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Damageable":
                // Do damage to other object then destroy this bullet
                Destroy(gameObject);
                break;
            case "Breakable":
                // Break the other object then destroy this bullet
                other.gameObject.GetComponent<BreakableObjectScript>().GetHit(damage);
                Destroy(gameObject);
                break;
            case "Player":
                // Check to see if the projectile was shot by the player before doing damage
                break;
            case "Bullet":
                // Do nothing so bullets don't break when hitting each other
                break;
            default:
                // Destroy this bullet
                Destroy(gameObject);
                break;

        }
    }
}
