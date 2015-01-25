using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f; 
	public float gravity = 20.0f;
	private int health = 100;
	//public AudioSource audio1;
	public AudioClip walking;
	private Vector3 moveDirection = Vector3.zero;
	public GameObject cam;
	private bool moving = false;
	CharacterController controller;

	void Start() {

		Screen.showCursor = false;
		this.GetComponent<playerMovement>().enabled = false;
		controller = gameObject.GetComponent<CharacterController>();
	}

	void Update() {
		//Debug.Log (moveDirection.x);
		//Debug.Log (moveDirection.z);
		//audio.clip = walking;
		if (controller.isGrounded) {
			if( Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d"))
				{
				moving = true;

				}
				if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("s") || Input.GetKeyUp("d"))
				{

				moving = false;
				}


			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			
			moveDirection = cam.transform.TransformDirection(moveDirection);
			moveDirection *= speed;


			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}


		moveDirection.y -= gravity * Time.deltaTime;

		controller.Move(moveDirection * Time.deltaTime);
	}

}