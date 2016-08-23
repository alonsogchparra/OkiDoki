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

		if(juice.lvlNumber <= 5 && juice.lvlNumber > 0) {
			player.canMove = true;
		} else if (player.currentState == Player.PlayerState.Sleepy) {
			player.canMove = false;
		}

	
	}

	void MovePlayer(){

	}



	void OnMouseOver(){
		this.GetComponent<SpriteRenderer>().color = hoverColor;

		if(Input.GetMouseButtonDown(0) && player.canMove) {
			juice.lvlNumber--;
			player.currentPosition = transform.position;


		}else if (Input.GetMouseButtonDown(0) && !player.canMove) {
			return;
		}

		print(player.canMove);

	}

	void OnMouseExit(){
		this.GetComponent<SpriteRenderer>().color = normalColor;
	}
}
