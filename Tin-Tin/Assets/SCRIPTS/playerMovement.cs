﻿using UnityEngine;
using System.Collections;
using System.Timers;

public class playerMovement : MonoBehaviour {
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f; 
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	public GameObject cam;

	void Start() {
		Screen.showCursor = false;
		gameObject.GetComponent<playerMovement>().enabled = false;

	}

	void Update() {

		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {

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