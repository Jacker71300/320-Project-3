using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public bool isInRangedMode = true;
    public bool firing = false;

    void Update()
    {
        // Determine buffered firing state
        if(Input.GetKeyDown(Controls.Instance.Fire) && !firing)
        {
            firing = true;
        }
        else if(Input.GetKeyUp(Controls.Instance.Fire) && firing)
        {
            firing = false;
        }
        else if(Input.GetKeyDown(Controls.Instance.Transform) // Determine if transform has been activated
            && GetComponent<PlayerStats>().TransformPercentage >= 100f 
            && !GetComponent<PlayerStats>().isTransformed)
        {
            GetComponent<PlayerStats>().isTransformed = true;
            isInRangedMode = false; // Go to melee mode
            GameObject.Find("Warden Spawner").GetComponent<WardenSpawner>().SpawnWarden();
        }

        if (firing)
        {
            // Ranged attacks
            if (isInRangedMode)
            {
                GetComponent<RangedWeaponScript>().Attack();
            }
            else // Melee attacks
            {
                GetComponent<MeleeWeaponScript>().Attack();
            }
            
        }

        
    }
}
