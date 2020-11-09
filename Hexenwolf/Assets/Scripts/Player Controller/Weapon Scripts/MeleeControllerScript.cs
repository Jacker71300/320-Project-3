using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeControllerScript : MonoBehaviour
{
    [SerializeField] float lifeTime;
    float lifeTimeLeft;

    [SerializeField] GameObject rightClaw;
    [SerializeField] GameObject leftClaw;
    [SerializeField] bool isClawLeft = false;
    bool active = false;

    // Update is called once per frame
    void Update()
    {
        if(lifeTimeLeft >= 0)
        {
            lifeTimeLeft -= Time.deltaTime;
        }
        else if(active)
        {
            if(leftClaw.activeSelf)
                leftClaw.SetActive(false);
            if(rightClaw.activeSelf)
                rightClaw.SetActive(false);

            active = false;
        }
    }

    public void Attack()
    {
        isClawLeft = !isClawLeft;
        //Make trigger active
        lifeTimeLeft = lifeTime;
        active = true;
        if (isClawLeft)
            leftClaw.SetActive(true);
        else
            rightClaw.SetActive(true);
    }
}
