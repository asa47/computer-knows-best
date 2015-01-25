using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectivesController : MonoBehaviour {

	public List<Objective> objectivesList;
	public bool isActive = false;
	public Text textScreen;
	public int index = 0;
	
	// Use this for initialization
	void Start () {

		objectivesList = new List<Objective>();
		objectivesList.Add (new Objective("E to interact", 10));
		objectivesList.Add (new Objective("Kill the monster", 20));
		objectivesList.Add (new Objective("Survive", 30));
		objectivesList.Add (new Objective("Dance!!!", 40));
	}

	void Update()
	{
		if(!isActive)
			transform.GetComponent<Image> ().color = Color.Lerp (transform.GetComponent<Image> ().color, Color.clear, 5.0f * Time.deltaTime);

		textScreen.color = new Color (textScreen.color.r, textScreen.color.g, textScreen.color.b, transform.GetComponent<Image> ().color.a * 1.2f);
		textScreen.text = objectivesList [index].description;
	}

}
