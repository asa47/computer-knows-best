using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class spawnAnimation : MonoBehaviour {
	public GameObject player;
	public GameObject camera;
	private float scriptTimer = 3.2f;
	// Use this for initialization
	void Start () {
		player.GetComponent<MouseLook>().enabled = false;
		camera.GetComponent<playerMovement>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<Image>().color = Color.Lerp (transform.GetComponent<Image>().color, Color.clear, 0.2f * Time.deltaTime);
		scriptTimer -= Time.deltaTime;
		if (scriptTimer <= 0) 
		{
			player.GetComponent<playerMovement> ().enabled = true;
			camera.GetComponent<MouseLook> ().enabled = true;
		}
		}
	}

