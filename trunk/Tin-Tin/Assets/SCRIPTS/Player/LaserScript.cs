using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public Vector3 startPosition;
	public Vector3 endPosition;

	private LineRenderer lineRenderer;
	private float timer = 0;

	void Start () {
		//Get and set the LineRenderer component
		lineRenderer = transform.GetComponent<LineRenderer> ();
		lineRenderer.SetWidth (0.2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {

		//Find the forward vector
		Vector3 fowardVector = endPosition - startPosition;
		fowardVector = fowardVector.normalized * 20;
		startPosition = startPosition + fowardVector * 1.2f * Time.deltaTime;
		endPosition = endPosition + fowardVector * Time.deltaTime;

		//Set the new position
		lineRenderer.SetPosition (0, startPosition);
		lineRenderer.SetPosition (1, endPosition);

		timer += Time.deltaTime;
		if(timer > 3.0f)
			Destroy(gameObject);
	}
}
