using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {


	public Juice juice;

	public GameObject[] floors;

	private Color hoverColor, normalColor;
	private Player player;
	private Dog dog;


	// Use this for initialization
	void Start () {

		hoverColor = new Color32(111, 159, 99, 255);
		normalColor = new Color32(255, 255, 255, 255);

		player = GameObject.Find("Oki").GetComponent<Player>();
		dog = GameObject.Find("Doki").GetComponent<Dog>();

	}
	
	// Update is called once per frame
	void Update () {

		if(juice.lvlNumber <= 5 && player.currentState != Player.PlayerState.Sleepy) {
			if(juice.lvlNumber < 1) {
				player.canMove = true;
			}
			player.canMove = true;
		} else if ( juice.lvlNumber <= 0 
			|| player.currentState == Player.PlayerState.Sleepy || player.playerBalloon.activeSelf) {
			player.canMove = false;
		}

		if(dog.currentState == Dog.DogState.Walking 
			|| dog.currentState == Dog.DogState.FindingBallon || player.playerBalloon.activeSelf) {

			player.currentPosition = player.transform.position;

			foreach(GameObject floor in floors) {
				floor.GetComponent<PolygonCollider2D>().enabled = false;
			}
		}

		if(dog.currentState == Dog.DogState.Eating || dog.currentState == Dog.DogState.HasBalloon) {
			foreach(GameObject floor in floors) {
				floor.GetComponent<PolygonCollider2D>().enabled = true;
			}
		}
	}

	void MovePlayer(){

	}



	void OnMouseOver(){
		this.GetComponent<SpriteRenderer>().color = hoverColor;

		if(Input.GetMouseButtonDown(0) && player.canMove && player.transform.position.x == transform.position.x) {
			juice.lvlNumber = juice.currentLvl;

		} else if(Input.GetMouseButtonDown(0) 
			&& player.canMove 
			&& player.transform.position.x != transform.position.x 
			&& player.currentState != Player.PlayerState.Sleepy) {

			juice.lvlNumber--;

			if(transform.position.x < player.transform.position.x) {
				player.direction = -1;

			}else if (transform.position.x >= player.transform.position.x){
				player.direction = 1;
			}

			player.actions++;
			player.currentPosition = transform.position;

			if(dog.currentState == Dog.DogState.Eating || dog.currentState == Dog.DogState.HasBalloon) {
				dog.dogCount++;
			}


		} else if (Input.GetMouseButtonDown(0) && !player.canMove && player.currentState == Player.PlayerState.Sleepy) {
//			return;
			player.currentPosition = player.transform.position;

		}
			

//		print(player.canMove);

	}

	void OnMouseExit(){
		this.GetComponent<SpriteRenderer>().color = normalColor;
	}
}
