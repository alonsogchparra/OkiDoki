using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public GameObject introPanel, tutorialPanel, tutorialPanelEng;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(introPanel.activeSelf) {

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
//				g.GetComponent<PolygonCollider2D>().enabled = false;
				g.SetActive(false);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
//				g.GetComponent<BoxCollider2D>().enabled = false;
				g.SetActive(false);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Keys")) {
//				g.GetComponent<BoxCollider2D>().enabled = false;
				g.SetActive(false);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Bowl")) {
//				g.GetComponent<BoxCollider2D>().enabled = false;
				g.SetActive(false);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonSeven")) {
//				g.GetComponent<CircleCollider2D>().enabled = false;
				g.SetActive(false);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonFive")) {
//				g.GetComponent<CircleCollider2D>().enabled = false;
				g.SetActive(false);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonTwo")) {
//				g.GetComponent<CircleCollider2D>().enabled = false;
				g.SetActive(false);
			}

		}
	
	}

	public void StartGame() {
		introPanel.SetActive(false);
		tutorialPanel.SetActive(true);
	}

	public void StartGameEng() {
		introPanel.SetActive(false);
		tutorialPanelEng.SetActive(true);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
