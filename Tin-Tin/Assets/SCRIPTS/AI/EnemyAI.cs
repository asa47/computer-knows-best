﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public Transform[] waypoints;

	public enum aiStates {Patrol, Attack};
	public float attackSpeed = 0.5f;
	public float patrolSpeed=3.0f;
	public float runSpeed=12f;
	public Transform[] playerReferences;
	private aiStates myState = aiStates.Patrol;
	private int waypointTargetIndex=0;
	private float nextAttackTime = 0.0f;

	public Animator enemyAnimate;

	public float viewDistance;
	public LayerMask rayMask; // LayerMask

	public int damage = 50;

	private NavMeshAgent agentRef;
	void Start()
	{
		nextAttackTime = Time.time + attackSpeed;
		agentRef = GetComponent<NavMeshAgent> ();
		StartCoroutine ("DetermineState");
		waypointTargetIndex = FindClosesWaypoint ();
		ChangeTarget (waypoints[waypointTargetIndex].transform.position,patrolSpeed);

		if(Application.isEditor)
		{
			StartCoroutine("DrawDebugPath");
		}
	}

	void Update()
	{
		DoAction ();
		if (myState == aiStates.Patrol) {
			//enemyAnimate.SetFloat ("speed", patrolSpeed);
		} else {
			enemyAnimate.SetFloat ("speed", runSpeed);
		}

	}
	
	
	public void DoAction() //call this every frame. It's like the update of the ai...
	{
		switch(myState)
		{
		case (aiStates.Patrol):
			PatrolAction();
			break;
		case (aiStates.Attack):
			AttackAction();
			break;
		}
	}
	
	IEnumerator DetermineState() 
	{
		while (true) 
		{
			if(IsPlayerVisible())
			{
				myState = aiStates.Attack;
				StopCoroutine("DetermineState");
			}
			yield return new WaitForSeconds(0.01f); 
		}
	}

	int currentTargetIndex = 0;
	
	bool IsPlayerVisible()
	{
		//cast ray towards player. if the ray hits something this means that the player is occluded. If it doesn't......check if the angle is smaller than the maximum visible angle...
		bool isVisible = false;
		RaycastHit hit;
		//Debug.Log (playerReference);
		for (int i=0; i<playerReferences.Length; i++) {
			if (Physics.Raycast (transform.position, playerReferences[i].transform.position - transform.position, out hit, viewDistance, rayMask)) { // Layer Mask and Distance
								print ("Hit: " + hit.point.ToString ());
								Debug.DrawLine (transform.position, hit.point, Color.blue);
								if (hit.collider.gameObject.tag == "Player") {

					if (Vector3.Angle (transform.forward, playerReferences[i].transform.position - transform.position) < 90) {
												isVisible = true;
						currentTargetIndex = i;
										}
								}
						}
				}
		if(isVisible)Debug.Log ("Player is visible? " + isVisible);
		return isVisible;
	}


	void PatrolAction()
	{
		if(Vector3.Distance(transform.position, waypoints[waypointTargetIndex].position)<4)
		{
			ChangeWaypointTarget();
			ChangeTarget(waypoints[waypointTargetIndex].transform.position,patrolSpeed);
		}
		//if distance.... GoTowards
		//else change target...
	}

	void AttackAction()
	{
		if(Vector3.Distance(transform.position, playerReferences[currentTargetIndex].transform.position)<5)
		{
			agentRef.speed = 0;
			agentRef.velocity = Vector3.zero;
			if(nextAttackTime<Time.time)
			{
				AttackPlayer();
			}
		}
		else
		{
			ChangeTarget(playerReferences[currentTargetIndex].transform.position,runSpeed);
		}
	}


	void ChangeTarget(Vector3 targetPos, float speed)
	{
		//play walk animation
		agentRef.SetDestination (targetPos);
		agentRef.speed = speed;
	}

	void ChangeWaypointTarget()
	{
		if(waypointTargetIndex+1>=waypoints.Length)
		{
			waypointTargetIndex = 0;
		}
		else
		{
			waypointTargetIndex++;
		}
	}

	int FindClosesWaypoint()
	{
		int closestIndex = 0;
		float closestDistance = Vector3.Distance(waypoints[0].position, transform.position);;
		for(int i=1;i<waypoints.Length;i++)
		{
			float tempDistance = Vector3.Distance(waypoints[i].position, transform.position);
			if(tempDistance<closestDistance)
			{
				closestDistance = tempDistance;
				closestIndex = i;
			}
		}
		return closestIndex;
	}

//	Tried to create collision
//	void OnCollisionEnter(Collision collision)
//	{
//		if (collision.gameObject.tag == "Player") 
//		{
//			Debug.Log("Player Engaged");
//			health = health-5;
//
//		}
//	}

	void AttackPlayer()
	{
		//Debug.Log ("player hit");
		nextAttackTime = Time.time + attackSpeed;

		if(playerReferences[currentTargetIndex].GetComponent<Health>()!=null)
		{
			playerReferences[currentTargetIndex].GetComponent<Health>().DealDamage(damage);
		}
		Debug.Log ("Player hit!!!!!!!!!!");

		//stop the ai movement...make speed 0...)
		//play attack animation and audio
		//deal damage
	}

	IEnumerator DrawDebugPath() 
	{
		while (true) 
		{
			//if player is visible = action is to attack
			//if player is not visible = go back to patroll...
			int nextWaypoint;
			for(int i=0;i<waypoints.Length;i++)
			{
				if(i+1>=waypoints.Length)
				{
					nextWaypoint = 0;
				}
				else
				{
					nextWaypoint = i+1;
				}
				Vector3 middlePoint = Vector3.Lerp(waypoints[i].transform.position,waypoints[nextWaypoint].transform.position,0.8f);
				Debug.DrawLine(waypoints[i].transform.position,middlePoint,Color.yellow);
				Debug.DrawLine(middlePoint,waypoints[nextWaypoint].transform.position,Color.red);
			}
			yield return null;
		}
	}


}