using UnityEngine;
using System.Collections;

public class Blender : MonoBehaviour {

	public GameObject blenderShine;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		blenderShine.SetActive(true);
	}

	void OnMouseExit(){
		blenderShine.SetActive(false);
	}
		
}
