﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour {

    public Transform plane;
	public PlayerControllerMapTut playerRef;
	private Vector3 safeHeavenPosition = new Vector3 (-900, 0, 50); 
	public GameObject merchantUI;


	void Start(){
		playerRef = FindObjectOfType<PlayerControllerMapTut> ();
		merchantUI = GameObject.FindGameObjectWithTag ("MerchantUI");
		merchantUI.SetActive (false);
	}

    // Load a new map
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
			
			Debug.Log ("makeDungeon " + Level.level.ToString());
            if (Level.level == 3) SceneManager.LoadScene("BossTheme"); 
            Level.level++;
            Debug.Log("level + 1");
            Instantiate(plane, FindObjectOfType<MapGenerator>().transform.position + new Vector3(0, 100, 0), Quaternion.identity); // MAKE NEW GROUND 
            FindObjectOfType<MapGenerator>().transform.position += new Vector3(0, 200, 0);
            FindObjectOfType<MapGenerator>().makeDungeon();
            FindObjectOfType<TimeController>().slowDown(2); // slow down time to emphasize transition
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
            FindObjectOfType<GameStateManager>().savePlayer();
            // SceneManager.LoadScene("Level3");

			//safe heaven
			if (Level.level % 1 == 0) {
				Debug.Log ("Go to safe heaven");
				playerRef.transform.position = safeHeavenPosition;
				merchantUI.SetActive (true);
			}

        }
    }

}
