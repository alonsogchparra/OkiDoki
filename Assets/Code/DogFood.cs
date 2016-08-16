using UnityEngine;
using System.Collections;

public class DogFood : MonoBehaviour {

	public GameObject dogFoodShine;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		dogFoodShine.SetActive(true);
	}

	void OnMouseExit(){
		dogFoodShine.SetActive(false);
	}
}
