using UnityEngine;
using System.Collections;

public class Presentation : MonoBehaviour {

	public GameObject initialViewPanel;
	public GameObject bgMusic;

	public GameObject likiSound;

	private float sec = 3.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		StartCoroutine(InitialViewActivated());
	
	}

	IEnumerator InitialViewActivated() {
		
		yield return new WaitForSeconds(sec);

		initialViewPanel.SetActive(true);
		bgMusic.SetActive(true);
		this.gameObject.SetActive(false);
		likiSound.SetActive(false);

	}
}
