﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float roundsPerMinute = 290f;

    [SerializeField] float timeToShoot = .1f;

    void Update()
    {
        if (timeToShoot > 0f)
            timeToShoot -= Time.deltaTime;
        else
            Attack();

    }

    public void Attack()
    {
        BulletScript Temp = Instantiate(projectile).GetComponent<BulletScript>();
        Temp.transform.position = transform.position;
        if (Temp != null)
        {
            Temp.Initialize(PlayerInfo.Instance.playerPos.position - transform.position, projectileSpeed, false) ;
        }
        timeToShoot += 60f / roundsPerMinute;

    }
}
