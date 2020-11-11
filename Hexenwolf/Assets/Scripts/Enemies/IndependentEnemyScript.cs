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
	[SerializeField] AIDestinationSetter targetSetter;
	[SerializeField] GameObject detector; //the graphics game object that holds which way the 
	AIState state;

	private void Start()
	{
		if (targetSetter == null)
		{
			targetSetter = GetComponent<AIDestinationSetter>();
			if (targetSetter == null)
			{
				Debug.LogError("IndependentEnemyScript on "+gameObject.name+" could not find an AIDestinationSetter");
			}
		}

		if (detector == null)
		{
			Debug.LogError("No Detector found on " +gameObject.name);
		}
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
				targetSetter.target = PlayerInfo.Instance.playerPos;
				return;
			}
			if (DetectAction())
			{
				state = AIState.PathtoAction;
				return;
			}

		}

	}

	private bool SpotPlayer()
	{
		return false;
	}

	private bool DetectAction()
	{
		return PlayerInfo.Instance.hasShot;
	}


	private void UpdateEngaged()
	{ 
		
	}

	private void UpdatePathToAction()
	{ 
	
	}

	private void UpdatePatrol()
	{
		
	}

}
