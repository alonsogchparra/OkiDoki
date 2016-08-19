using UnityEngine;
using System.Collections;

public class Blender : MonoBehaviour {

	public GameObject blenderShine;
	private Juice juice;

	// Use this for initialization
	void Start () {

		juice = GameObject.Find("Juice").GetComponent<Juice>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		blenderShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && juice.lvlNumber < 5) {

			juice.lvlNumber = 5;

		}

	}

	void OnMouseExit(){
		blenderShine.SetActive(false);
	}
		
}
