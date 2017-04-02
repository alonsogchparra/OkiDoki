using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivinRoom : MonoBehaviour {

	public GameObject tutorialPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (tutorialPanel.activeSelf ) {
			return;
		} 
		else if(!tutorialPanel.activeSelf ) {

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
				g.GetComponent<PolygonCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
				g.GetComponent<BoxCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("DogToy")) {
				g.GetComponent<BoxCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("CouchOne")) {
				g.GetComponent<BoxCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("CouchTwo")) {
				g.GetComponent<BoxCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("CouchThree")) {
				g.GetComponent<BoxCollider2D>().enabled = true;
			}

		}
		
	}
}
