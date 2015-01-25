using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	public int health = 100;

	void Start()
	{
		foreach(Collider col in GetComponentsInChildren<Collider>())
		{
			if(collider != col)
				col.enabled = false;
		}
	}

	public void DealDamage(int ammount)
	{
		health -= ammount;

		if(health<0)
		{
			ActivateRagdoll();
		}
	}
	
	void ActivateRagdoll()
	{
		if (GetComponent<NPCAI> () != null) 
		{
			GetComponent<NPCAI> ().enabled =false;
		}
		if (GetComponent<EnemyAI> () != null) 
		{
			GetComponent<EnemyAI> ().enabled =false;
		}
		if (GetComponent<NavMeshAgent> () != null) 
		{
			GetComponent<NavMeshAgent> ().enabled =false;
		}
		if (GetComponent<Animator> () != null) 
		{
			GetComponent<Animator> ().enabled =false;
		}
		if (GetComponent<Collider> () != null) 
		{
			GetComponent<Collider> ().enabled =false;
		}

		foreach(Collider col in GetComponentsInChildren<Collider>())
		{
			if(collider != col)
				col.enabled = true;
		}

	}

}
