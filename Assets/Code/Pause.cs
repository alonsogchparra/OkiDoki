using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

}
