using UnityEngine;
using System.Collections;

public class FridgePanelControl : MonoBehaviour {

	public GameObject fridgePanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!fridgePanel.activeSelf) {
			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
				g.GetComponent<PolygonCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
				g.GetComponent<BoxCollider2D>().enabled = true;
			}

		} else {

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
				g.GetComponent<PolygonCollider2D>().enabled = false;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
				g.GetComponent<BoxCollider2D>().enabled = false;

			}
		}
	
	}
}
