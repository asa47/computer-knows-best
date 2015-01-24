using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class spawnAnimation : MonoBehaviour {
	public GameObject player;
	public GameObject playerCamera;
	private float scriptTimer = 3.2f;
	// Use this for initialization
	void Start () {
//		player.GetComponent<MouseLook>().enabled = false;
//		playerCamera.GetComponent<playerMovement>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<Image>().color = Color.Lerp (transform.GetComponent<Image>().color, Color.clear, 0.45f * Time.deltaTime);
		scriptTimer -= Time.deltaTime;
		if (scriptTimer <= 0) 
		{
			player.GetComponent<playerMovement>().enabled = true;
			playerCamera.GetComponent<MouseLook>().enabled = true;

		}
		}
	}

