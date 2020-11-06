﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponScript : MonoBehaviour
{
    [SerializeField] GameObject meleeTrigger;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float roundsPerMinute = 290f;

    float timeToShoot;

    // Update is called once per frame
    void Update()
    {
        if (timeToShoot > 0f)
            timeToShoot -= Time.deltaTime;
    }

    public void Attack()
    {
        if (timeToShoot <= 0f)
        {
            meleeTrigger.GetComponent<MeleeTriggerScript>().Attack();
            timeToShoot += 60f / roundsPerMinute;

            GetComponent<PlayerWeaponController>().firing = false;
        }
    }
}
