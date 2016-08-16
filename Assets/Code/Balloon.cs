using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	public GameObject balloonShine;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		balloonShine.SetActive(true);
	}

	void OnMouseExit(){
		balloonShine.SetActive(false);
	}
}
