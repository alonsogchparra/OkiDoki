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

		if(player.currentState != Player.PlayerState.Sleepy && player.canMove) {

			MovePlayer();

		}
	
	}

	void MovePlayer(){

		player._isFacingRight = player.transform.localScale.x > 0;

		if(player._isFacingRight) {
			player.Flip();
		}


		if(player.transform.position != transform.position) {

			player.transform.position = Vector3.MoveTowards(
				player.transform.position, 
				transform.position, 
				Time.deltaTime * player.speed );

		}





	}



	void OnMouseOver(){
		this.GetComponent<SpriteRenderer>().color = hoverColor;

		if(Input.GetMouseButtonDown(0) && juice.lvlNumber <= 5) {
			player.canMove = true;
			juice.lvlNumber--;

		}else if (Input.GetMouseButtonDown(0) && juice.lvlNumber == 0) {
			player.canMove = false;
		}

	}

	void OnMouseExit(){
		this.GetComponent<SpriteRenderer>().color = normalColor;
	}
}
