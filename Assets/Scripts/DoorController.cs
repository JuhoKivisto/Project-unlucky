﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	Vector3 currentPosition;





	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Walls") {
			Debug.Log ("Door colliding with wall");

		}

	}



}
