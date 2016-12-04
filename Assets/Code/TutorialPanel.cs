using UnityEngine;
using System.Collections;

public class TutorialPanel : MonoBehaviour {

	public GameObject tutorialPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(tutorialPanel.activeSelf) {

//			print("Desactivo todos los colliders");

//						foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
//							g.GetComponent<PolygonCollider2D>().enabled = false;
//						}
			//
			//			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
			//				g.GetComponent<BoxCollider2D>().enabled = false;
			//
			//			}
			//
			//			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Keys")) {
			//				g.GetComponent<BoxCollider2D>().enabled = false;
			//			}
			//
			//			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Bowl")) {
			//				g.GetComponent<BoxCollider2D>().enabled = false;
			//			}
			//
			//			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonSeven")) {
			//				g.GetComponent<CircleCollider2D>().enabled = false;
			//			}
			//
			//			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonFive")) {
			//				g.GetComponent<CircleCollider2D>().enabled = false;
			//			}
			//
			//			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonTwo")) {
			//				g.GetComponent<CircleCollider2D>().enabled = false;
			//			}



		} else {

//			print("Activo todos los colliders");

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
//				g.GetComponent<PolygonCollider2D>().enabled = true;
				g.SetActive(true);
				
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
//				g.GetComponent<BoxCollider2D>().enabled = true;
				g.SetActive(true);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Keys")) {
//				g.GetComponent<BoxCollider2D>().enabled = true;
				g.SetActive(true);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("Bowl")) {
//				g.GetComponent<BoxCollider2D>().enabled = true;
				g.SetActive(true);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonSeven")) {
//				g.GetComponent<CircleCollider2D>().enabled = true;
				g.SetActive(true);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonFive")) {
//				g.GetComponent<CircleCollider2D>().enabled = true;
				g.SetActive(true);
			}

			foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonTwo")) {
//				g.GetComponent<CircleCollider2D>().enabled = true;
				g.SetActive(true);
			}

		}
	
	}

	public void ActivateGame() {
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
			//				g.GetComponent<PolygonCollider2D>().enabled = true;
			g.SetActive(true);

		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
			//				g.GetComponent<BoxCollider2D>().enabled = true;
			g.SetActive(true);
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Keys")) {
			//				g.GetComponent<BoxCollider2D>().enabled = true;
			g.SetActive(true);
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Bowl")) {
			//				g.GetComponent<BoxCollider2D>().enabled = true;
			g.SetActive(true);
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonSeven")) {
			//				g.GetComponent<CircleCollider2D>().enabled = true;
			g.SetActive(true);
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonFive")) {
			//				g.GetComponent<CircleCollider2D>().enabled = true;
			g.SetActive(true);
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonTwo")) {
			//				g.GetComponent<CircleCollider2D>().enabled = true;
			g.SetActive(true);
		}
	}
}
