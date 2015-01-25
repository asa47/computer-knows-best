using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class spawnAnimation : MonoBehaviour {
	public GameObject player;
	public GameObject playerCamera1;
	public GameObject playerCamera2;
	public GameObject playerAnimator;
	private float scriptTimer = 5.0f;

	// Use this for initialization
	void Start () {
//		player.GetComponent<MouseLook>().enabled = false;
//		playerCamera.GetComponent<playerMovement>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<Image>().color = Color.Lerp (transform.GetComponent<Image>().color, Color.clear, 0.2f * Time.deltaTime);
		scriptTimer -= Time.deltaTime;
		if (scriptTimer <= 0) 
		{
			playerAnimator.GetComponent<pAnimator>().enabled=true;
			player.GetComponent<playerMovement>().enabled = true;
			playerCamera1.GetComponent<MouseLook2>().enabled = true;
			playerCamera2.GetComponent<MouseLook2>().enabled = true;
			enabled = false;
		}
		}
	
	}

