using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

	private Color hoverColor, normalColor;

	// Use this for initialization
	void Start () {

		hoverColor = new Color32(111, 159, 99, 255);
		normalColor = new Color32(255, 255, 255, 255);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		this.GetComponent<SpriteRenderer>().color = hoverColor;
	}

	void OnMouseExit(){
		this.GetComponent<SpriteRenderer>().color = normalColor;
	}
}
