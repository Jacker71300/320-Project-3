using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
	Patrol,
	FollowTrail,
	PathtoAction,
	Engage,
	Wait
}

public class IndependentEnemyScript : MonoBehaviour
{
	AIState state;
	private void Update()
	{
		UpdateAiState();

		switch (state)
		{
			case AIState.Patrol:

				break;
		}

	}

	private void UpdateAiState()
	{

		if (state != AIState.Engage)
		{

			if (SpotPlayer())//if we are not engaged already and we've spotted the player
			{
				state = AIState.Engage;
				return;
			}
			if (DetectAction())
			{
				state = AIState.PathtoAction;
				return;
			}

			if (SpotTrail())
			{
				state = AIState.FollowTrail;
				return;
			}
		}
		else if(PlayerEscaped())
		{
			state = AIState.Patrol;
		}

	}

	private bool SpotPlayer()
	{
		return false;
	}

	private bool DetectAction()
	{
		return false;
	}

	private bool SpotTrail()
	{
		return false;
	}

	private bool PlayerEscaped()
	{
		return false;
	}
}
