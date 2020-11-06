using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] bool isInRangedMode = true;
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
