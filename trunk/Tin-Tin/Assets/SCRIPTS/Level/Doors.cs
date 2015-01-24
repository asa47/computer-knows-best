using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {
	
	public GameObject leftDoor;
	public GameObject rightDoor;
	public float doorSpeed;
	public float doorLimitL;
	public float doorLimitR;
	private float limitCountL;
	private float limitCountR;
	private bool Activated;
	bool closingDoors = true;
	bool openingDoors = false;

	
	void OnTriggerEnter (Collider target)
	{
		if (!Activated) {

						if (target.gameObject.tag == "Player") {
								openingDoors = true;
								closingDoors = false;
								//Debug.Log ("Collided");
						}
				}
	}
	void OnTriggerExit (Collider target)
	{
		Activated = false;
		if (target.gameObject.tag == "Player") 
		{
			openingDoors = false;
			closingDoors = true;
			//Debug.Log ("Exited");
		}
	}

	
	void Update ()
	{
		if (openingDoors) {
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
		else if(closingDoors)
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
/*	public Transform targeti;
	public Transform targetu;
	public float doorSpeed = 0.7f;
	public float slideDistance = 0.0f;
	private Vector3 initPositioni;
	private Vector3 initPositionu;
	private bool doorOpen = false;
	// Use this for initialization
	void Start () {
		initPositioni = targeti.transform.position;
		initPositionu = targetu.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//StartCoroutine (OnTriggerEnter());
		if (!targeti) 
		{
			return;
		}
		if (!targetu) 
		{
			return;
		}

		if (doorOpen == true) 
		{
			targeti.localPosition = new Vector3(Mathf.Min (slideDistance, targeti.position.x + doorSpeed * Time.deltaTime),targeti.position.y, targeti.position.z);
			targetu.localPosition = new Vector3(Mathf.Min (slideDistance, targetu.position.x - doorSpeed * Time.deltaTime),targetu.position.y, targetu.position.z);
		} 
		else 
		{
			targeti.position = new Vector3(targeti.position.x,targeti.position.y,(Mathf.Min (initPositioni.z, targeti.position.z - doorSpeed * Time.deltaTime)));
			targetu.position = new Vector3(targetu.position.x,targetu.position.y,(Mathf.Min (initPositionu.z, targetu.position.z + doorSpeed * Time.deltaTime)));
		}

	}
}
	/*IEnumerator OnTriggerEnter(Collider target)
	{
		yield return new WaitForSeconds (1);
	}

	IEnumerator OnTriggerExit()
	{
		yield return new WaitForSeconds (1);
	}
}*/
