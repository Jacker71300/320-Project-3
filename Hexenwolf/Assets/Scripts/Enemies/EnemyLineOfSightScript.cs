using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyLineOfSightScript : MonoBehaviour
{
    // Mask for everything that isn't walls or the player
    private LayerMask mask;

    private void Start()
    {
        mask = LayerMask.GetMask("Walls", "Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = PlayerInfo.Instance.playerPos.position - transform.position;
        Debug.Log("direction: " + direction);
        Debug.Log("location: " + PlayerInfo.Instance.playerPos.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 10f, mask.value);

        Debug.DrawLine(transform.position, direction * 10f, Color.red);
        Debug.DrawLine(transform.position, PlayerInfo.Instance.playerPos.position, Color.blue);
        Debug.Log(hit.transform);

        if(hit.transform.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
