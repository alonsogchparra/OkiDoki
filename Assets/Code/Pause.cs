using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject pausePanel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		switch(sceneName) {

		case "Kitchen":

			if(!pausePanel.activeSelf) {

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


			break;

		case "LivinRoom":


			if(!pausePanel.activeSelf) {

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

			} else {

				foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
					g.GetComponent<PolygonCollider2D>().enabled = false;
				}

				foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
					g.GetComponent<BoxCollider2D>().enabled = false;

				}

				foreach(GameObject g in GameObject.FindGameObjectsWithTag("DogToy")) {
					g.GetComponent<BoxCollider2D>().enabled = false;
				}

				foreach(GameObject g in GameObject.FindGameObjectsWithTag("CouchOne")) {
					g.GetComponent<BoxCollider2D>().enabled = false;
				}

				foreach(GameObject g in GameObject.FindGameObjectsWithTag("CouchTwo")) {
					g.GetComponent<BoxCollider2D>().enabled = false;
				}

				foreach(GameObject g in GameObject.FindGameObjectsWithTag("CouchThree")) {
					g.GetComponent<BoxCollider2D>().enabled = false;
				}

			}

			break;

		default:
		break;
		}
	
	}

	public void PausePanelActivated() {

		pausePanel.SetActive(true);

	}

	public void PausePanelDeactivated() {

		pausePanel.SetActive(false);

	}

	public void RestartGame() {
//		Normally I would use this to reolad the scene, but Unity tells me this is obselete. So I going to use the 
//		other way to reload the scene
//		Application.LoadLevel(Application.loadedLevel);

		SceneManager.LoadScene(0);

	}

	public void ExitGame() {

		Application.Quit();

	}

	public void LevelTwo() {

		SceneManager.LoadScene(1);
	}

}
