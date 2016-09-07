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

}
