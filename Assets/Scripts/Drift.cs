/* Author: Selina Daley */
/* File: Drift.cs */
/* Creation Date: October 05, 2015 */
/* Description: This script moves the Gameobject it is attached to left, right, up, and/or down on the screen */

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public class Speed{
	public float xMin, xMax, yMin, yMax;
}

public class Drift : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public Speed speed;
	public Boundary boundary;
	
	//PRIVATE INTSTANCE VARIABLES
	private float _currentSpeed;
	private float _currentDrift;

	// Use this for initialization
	void Start () {
		this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = new Vector2 (this.transform.position.x, this.transform.position.y);
		currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y += this._currentSpeed; //Move object down the screen
		currentPosition.x += this._currentDrift; //Move object left or right
		
		//Move the gameObject to the currentPosition
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		//Top boundary check - gameObject meets top of camera viewport
		if (currentPosition.y <= boundary.yMin) {
			this._Reset();
		}
	}

	// Resets our gameObject
	private void _Reset() {
		this._currentSpeed = Random.Range (speed.yMin, speed.yMax);
		this._currentDrift = Random.Range (speed.xMin, speed.xMax);
		Vector2 resetPosition = new Vector2 (Random.Range (boundary.xMin, boundary.xMax), boundary.yMax);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}
}
