using UnityEngine;
using System.Collections;

public class InfoPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Twitter() {
		Application.OpenURL("https://twitter.com/LikinventStudio/");
	}

	public void Instagram() {
		Application.OpenURL("https://www.instagram.com/likinventstudio/");
	}

	public void Facebook() {
		Application.OpenURL("https://www.facebook.com/likinventstudio/");
	}
}
