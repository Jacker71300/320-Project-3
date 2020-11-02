using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 20f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BulletScript Temp = Instantiate(projectile).GetComponent<BulletScript>();
            Temp.transform.position = transform.position;
            if (Temp != null)
            {
                Temp.Initialize(Camera.main.ScreenToWorldPoint(Input.mousePosition) -transform.position,projectileSpeed);
            }
            
        }
        
    }
}
