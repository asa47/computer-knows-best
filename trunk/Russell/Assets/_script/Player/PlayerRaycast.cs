using UnityEngine;
using System.Collections;

public class PlayerRaycast : MonoBehaviour {

	private float timer = 0;
	private bool laserOn = false;
	private ParticleSystem particle;

	// Use this for initialization
	void Start () {
		particle = GameObject.FindGameObjectWithTag ("Laser").GetComponent<ParticleSystem> ();
		particle.Stop ();
	}
	
	// Update is called once per frame
	void Update () {

		if(!laserOn && Input.GetMouseButtonDown(0)){
			particle.Play();
			laserOn = true;
		}

		if(laserOn)
		{
			timer += Time.deltaTime;
			RaycastHit hit;
			if(Physics.Raycast (transform.position, transform.forward, out hit, 10.0f)) {
				//Debug.Log(hit.transform.name);
			}

			if(timer > 0.5){
				timer = 0;
				laserOn = false;
				particle.Stop();
			}

		} 
	}


}
