using UnityEngine;
using System.Collections;

public class DoorSpawnEnter : MonoBehaviour {
	
	public GameObject leftDoor;
	public GameObject rightDoor;
	public float doorSpeed;
	public float doorLimitL;
	public float doorLimitR;
	private float limitCountL;
	private float limitCountR;
	private bool Activated;
	bool closing1Door = true;
	bool opening1Door = false;
	
	
	void OnTriggerEnter (Collider target)
	{
		if (!Activated) {
			
			if (target.gameObject.tag == "Player"||target.gameObject.tag == "Enemy") {
				opening1Door = true;
				closing1Door = false;
				//Debug.Log ("Collided");
			}
		}
	}
	void OnTriggerExit (Collider target)
	{
		Activated = false;
		if (target.gameObject.tag == "Player") 
		{
			opening1Door = false;
			closing1Door = true;
			//Debug.Log ("Exited");
		}
	}
	
	
	void Update ()
	{
		if (opening1Door) {
			if (limitCountL >= doorLimitL) 
			{
				leftDoor.transform.position = new Vector3 (leftDoor.transform.position.x - doorSpeed, leftDoor.transform.position.y, leftDoor.transform.position.z);    
				limitCountL -= doorSpeed;
			}
			if (limitCountR <= doorLimitR) 
			{
				rightDoor.transform.position = new Vector3 (rightDoor.transform.position.x + doorSpeed, rightDoor.transform.position.y, rightDoor.transform.position.z);    
				limitCountR += doorSpeed;
			}
		} 
		else if(closing1Door)
		{
			if (limitCountL <= 0) 
			{
				leftDoor.transform.position = new Vector3 (leftDoor.transform.position.x + doorSpeed, leftDoor.transform.position.y, leftDoor.transform.position.z);    
				limitCountL += doorSpeed;
			}
			if (limitCountR >= 0) 
			{
				rightDoor.transform.position = new Vector3 (rightDoor.transform.position.x - doorSpeed, rightDoor.transform.position.y, rightDoor.transform.position.z);    
				limitCountR -= doorSpeed;
			}
		}
	}
}
