using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {


	public Juice juice;

	private Color hoverColor, normalColor;
	private Player player;


	// Use this for initialization
	void Start () {

		hoverColor = new Color32(111, 159, 99, 255);
		normalColor = new Color32(255, 255, 255, 255);

		player = GameObject.Find("Oki").GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void MovePlayer(){

	}



	void OnMouseOver(){
		this.GetComponent<SpriteRenderer>().color = hoverColor;

		if(Input.GetMouseButtonDown(0) && juice.lvlNumber <= 5) {
			player.canMove = true;
			juice.lvlNumber--;
			player.currentPosition = transform.position;


		}else if (Input.GetMouseButtonDown(0) && juice.lvlNumber == 0) {
			player.canMove = false;
		}

	}

	void OnMouseExit(){
		this.GetComponent<SpriteRenderer>().color = normalColor;
	}
}
