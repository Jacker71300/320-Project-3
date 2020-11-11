using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public enum AIState
{
	Patrol,
	PathtoAction,
	Engage,
	Wait
}

public class IndependentEnemyScript : MonoBehaviour
{
	[SerializeField] GameObject enemyTarget;
	[SerializeField] float hearingRadius = 4f;
	[SerializeField] EnemyVisionCone visionCone;
	[SerializeField] float playerSpottingEscapeTime = 2f;
	[SerializeField] float investigationTime = 4f;
	[SerializeField] LayerMask playerLayer;
	[SerializeField] LayerMask visionObstructingLayer;
	float timeSinceLastSpottedPLayer = 0f;
	float waitTimer = 0f;
	AIState state = AIState.Patrol;

	private void Start()
	{

		if (visionCone == null)
		{
			visionCone = GetComponentInChildren<EnemyVisionCone>();
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, hearingRadius);
		Gizmos.DrawLine(transform.position, transform.position + transform.up * 6);
	}

	private void Update()
	{
		UpdateAiState();

		if (state == AIState.Engage)
		{
			UpdateEngaged();
			return;
		}

		if (state == AIState.PathtoAction)
		{
			UpdatePathToAction();
		}

		if (state == AIState.Patrol)
		{
			UpdatePatrol();
		}

	}

	private void UpdateAiState()
	{

		if (state != AIState.Engage)
		{

			if (SpotPlayer())//if we are not engaged already and we've spotted the player
			{
				state = AIState.Engage;
				enemyTarget.transform.position = PlayerInfo.Instance.playerPos.position;
				return;
			}
			if (DetectAction())
			{
				state = AIState.PathtoAction;
				enemyTarget.transform.position = PlayerInfo.Instance.playerPos.position;
				return;
			}

		}

	}

	private bool SpotPlayer()
	{
		if (visionCone.CanSeePlayer(playerLayer)){
			Debug.Log("sees player in vision cone");
			RaycastHit2D line = Physics2D.Raycast(transform.position, PlayerInfo.Instance.playerPos.transform.position - transform.position, 100f, visionObstructingLayer);
			if (!line)
			{
				return true;
			}
		}

		return false;
	}

	private bool DetectAction()
	{
		return PlayerInfo.Instance.hasShot && (PlayerInfo.Instance.playerPos.transform.position - transform.position).magnitude < hearingRadius;
	}


	private void UpdateEngaged()
	{
		enemyTarget.transform.position = PlayerInfo.Instance.transform.position;
	}

	private void UpdatePathToAction()
	{ 
	
	}

	private void UpdatePatrol()
	{
		
	}

}
