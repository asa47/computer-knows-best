using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	int health = 100;

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

	}

}
