using UnityEngine;
using System.Collections;

public class pAnimator : MonoBehaviour {
	Animator animator;

//	private bool moving = false;
	private float scriptTimer = 5.0f;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		//this.GetComponent<Animator>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		scriptTimer -= Time.deltaTime;
		if (scriptTimer <= 0) 
		{
			float move = Input.GetAxis ("Vertical");


			animator.SetFloat ("speed", move);

		}
	}
}
