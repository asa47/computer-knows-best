using UnityEngine;
using System.Collections;

public class PlayerRaycast : MonoBehaviour {

	public GameObject prefabLaser;
	//Created Timer for intermission sequence
	public GameObject laserSpawnPoint;
	public AudioClip gunShot;
	private float scriptTimer = 0.0f;
	//private GameObject camera;

	public int damage=50; 
	public LayerMask raycastMask;

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
			GameObject laser = Instantiate (prefabLaser, laserSpawnPoint.transform.position, laserSpawnPoint.transform.rotation) as GameObject;
				laser.GetComponent<LaserScript> ().startPosition = laser.transform.position;
				laser.GetComponent<LaserScript> ().endPosition = transform.position + Camera.main.transform.forward * 10 + Vector3.up * 1.0f;





				RaycastHit hit;
				if (Physics.Raycast (laserSpawnPoint.transform.position, laserSpawnPoint.transform.forward, out hit,raycastMask)) {
						Debug.Log (hit.transform.name);
					//Debug.DrawLine(hit.point, transform.position, Color.red);
					if(hit.collider.gameObject.GetComponent<Health>())
					{
						hit.collider.gameObject.GetComponent<Health>().DealDamage(damage);
					}
				}
			}
	}
	}


}
