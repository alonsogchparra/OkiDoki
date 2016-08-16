using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {

	public GameObject keysShine;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		keysShine.SetActive(true);
	}

	void OnMouseExit(){
		keysShine.SetActive(false);
	}
}
