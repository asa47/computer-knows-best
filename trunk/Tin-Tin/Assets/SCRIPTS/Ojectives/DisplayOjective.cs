using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayOjective : MonoBehaviour {

	//Set the objective through this index
	public int indexOjective = 0;

	private GameObject objectivesController;
	private float timer = 0;

	void Start()
	{
		//Get the ObjectiveController
		objectivesController = GameObject.FindGameObjectWithTag ("ObjectiveController");
	}

	void OnTriggerStay (Collider other) {
		//If the player is in the room show the objective
		if(other.gameObject.tag == "Player" && timer < 5.0f)
		{
			objectivesController.GetComponent<Image> ().color = Color.Lerp (objectivesController.GetComponent<Image> ().color, new Color(1f, 1f, 1f, 0.5f), 2.0f * Time.deltaTime);
			objectivesController.GetComponent<ObjectivesController>().index = indexOjective;
			objectivesController.GetComponent<ObjectivesController>().isActive = true;
			timer += Time.deltaTime;
		}else
		{
			objectivesController.GetComponent<ObjectivesController>().isActive = false;
		}
	}

	void OnTriggerExit (Collider other) {
		if(other.gameObject.tag == "Player"){
			objectivesController.GetComponent<ObjectivesController>().isActive = false;
			timer = 0;
		}
	}




}
