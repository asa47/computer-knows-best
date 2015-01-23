using UnityEngine;
using System.Collections;

public class Objective {

	public string description;
	public bool completed;
	public int points;

	public Objective (string _description, int _points, bool completed = false)
	{
		description = _description;
		points = _points;

	}

}
