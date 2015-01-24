using UnityEngine;
using System.Collections;

public class UpperBodyRotation : MonoBehaviour 
{
	void LateUpdate()
	{
		Vector3 v = Camera.main.transform.forward * 1000;
		transform.LookAt (v, Camera.main.transform.up);
	}
}
