using UnityEngine;
using System.Collections;

public class NPCAI : MonoBehaviour 
{
	public float followSpeed = 0.5f;
	public GameObject playerReference;
	private bool followPlayer = false;
	private NavMeshAgent agentRef;
	
	void Start()
	{
		playerReference = GameObject.FindGameObjectWithTag ("Player");
		agentRef = GetComponent<NavMeshAgent> ();
	}

	void Update()
	{
		if(Vector3.Distance(playerReference.transform.position,transform.position)<6)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				if(followPlayer)
				{
					StopCoroutine("SetDestinationToPlayer");
					followPlayer = false;
				}
				else
				{
					StartCoroutine("SetDestinationToPlayer");
					followPlayer = true;
				}
			}
		}


	}




	IEnumerator SetDestinationToPlayer() 
	{
		while (true) 
		{
			agentRef.SetDestination(playerReference.transform.position);
			yield return new WaitForSeconds(0.1f); 
		}
	}

}