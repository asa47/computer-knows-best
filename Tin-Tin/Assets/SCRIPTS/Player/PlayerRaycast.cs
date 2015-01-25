using UnityEngine;
using System.Collections;

public class PlayerRaycast : MonoBehaviour {

	public GameObject prefabLaser;
	//Created Timer for intermission sequence
	public AudioClip gunShot;
	private float scriptTimer = 5.0f;
	//private GameObject camera;

	void Start () {
		//Get the main camera object
		//camera = GameObject.FindGameObjectWithTag ("MainCamera");

	}
	
	// Update is called once per frame
	void Update () {
		scriptTimer -= Time.deltaTime;
		//if script timer reaches <= 0, allow player to activate mouse click
		if (scriptTimer <= 0) {
						//On mouse click instantiate a new prefab laser and set the position
						if (Input.GetMouseButtonDown (0)) {
				         audio.PlayOneShot(gunShot);
								GameObject laser = Instantiate (prefabLaser, transform.position + Vector3.up * 0.5f, Quaternion.identity) as GameObject;
								laser.GetComponent<LaserScript> ().startPosition = laser.transform.position;
								laser.GetComponent<LaserScript> ().endPosition = transform.position + Camera.main.transform.forward * 10 + Vector3.up * 1.0f;

								RaycastHit hit;
								if (Physics.Raycast (laser.transform.position, laser.GetComponent<LaserScript> ().endPosition, out hit, 20.0f)) {
										Debug.Log (hit.transform.name);
								}
						}
				}
	}


}
