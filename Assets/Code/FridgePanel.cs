using UnityEngine;
using System.Collections;

public class FridgePanel : MonoBehaviour {

	public GameObject frigdePanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!frigdePanel.activeSelf) {

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
				g.GetComponent<PolygonCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
				g.GetComponent<BoxCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Keys")) {
				g.GetComponent<BoxCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Bowl")) {
				g.GetComponent<BoxCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonSeven")) {
				g.GetComponent<CircleCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonFive")) {
				g.GetComponent<CircleCollider2D>().enabled = true;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonTwo")) {
				g.GetComponent<CircleCollider2D>().enabled = true;
			}
			
		} else {

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
				g.GetComponent<PolygonCollider2D>().enabled = false;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
				g.GetComponent<BoxCollider2D>().enabled = false;

			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Keys")) {
				g.GetComponent<BoxCollider2D>().enabled = false;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Bowl")) {
				g.GetComponent<BoxCollider2D>().enabled = false;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonSeven")) {
				g.GetComponent<CircleCollider2D>().enabled = false;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonFive")) {
				g.GetComponent<CircleCollider2D>().enabled = false;
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonTwo")) {
				g.GetComponent<CircleCollider2D>().enabled = false;
			}
			
		}

	}
}
