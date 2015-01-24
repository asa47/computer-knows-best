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
		objectivesList.Add (new Objective("Objective 1", 10));
		objectivesList.Add (new Objective("Objective 2", 20));
		objectivesList.Add (new Objective("Objective 3", 30));
		objectivesList.Add (new Objective("Objective 4", 40));
	}

	void Update()
	{
		if(!isActive)
			transform.GetComponent<Image> ().color = Color.Lerp (transform.GetComponent<Image> ().color, Color.clear, 5.0f * Time.deltaTime);

		textScreen.color = new Color (textScreen.color.r, textScreen.color.g, textScreen.color.b, transform.GetComponent<Image> ().color.a);
		textScreen.text = objectivesList [index].description;
	}

}
