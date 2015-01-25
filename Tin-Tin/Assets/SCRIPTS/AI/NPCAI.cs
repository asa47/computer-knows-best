using UnityEngine;
using System.Collections;

public class NPCAI : MonoBehaviour 
{
	public float followSpeed = 0.5f;
	public GameObject playerReference;
	private bool followPlayer = false;
	private NavMeshAgent agentRef;
	private Animator anim;
	void Start()
	{
		playerReference = GameObject.FindGameObjectWithTag ("Player");
		agentRef = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
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
					anim.SetFloat("Speed",0f);
					followPlayer = false;
				}
				else
				{
					StartCoroutine("SetDestinationToPlayer");
					anim.SetFloat("Speed",1f);
					followPlayer = true;
				}
			}
		}


	}




	IEnumerator SetDestinationToPlayer() 
	{
		while (true) 
		{
			if(agentRef!=null)
			{
				agentRef.SetDestination(playerReference.transform.position);
			}
			yield return new WaitForSeconds(0.1f); 
		}
	}

}