using UnityEngine;
using System.Collections;

public class StartAds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void StartVideo () {
		AdManager.Instance.ShowVideo();
	}
}
