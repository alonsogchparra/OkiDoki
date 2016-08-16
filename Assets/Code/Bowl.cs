using UnityEngine;
using System.Collections;

public class Bowl : MonoBehaviour {

	public GameObject bowlShine;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		bowlShine.SetActive(true);
	}

	void OnMouseExit(){
		bowlShine.SetActive(false);
	}
}
