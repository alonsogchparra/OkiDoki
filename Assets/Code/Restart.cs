using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

	public GameObject playerBowl, panel, playerBalloon, playerKeys;

	Bowl bowl;
	Player player;
	Juice juice;
	Balloon balloonSeven, balloonFive, balloonTwo;
	Dog dog;
	Keys keys;
	Door door; 
	AdManager adManager;

	Vector3 posPlayer = new Vector3 (-4.233907f, -3.727f, 0);
	Vector3 posDog = new Vector3 (-2.78f, -1.46f, 0);

	int count = 0;

	// Use this for initialization
	void Start () {

		bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
		player = GameObject.Find("Oki").GetComponent<Player>();
		juice = GameObject.Find("Juice").GetComponent<Juice>();
		balloonTwo = GameObject.Find("Balloon Floor Two").GetComponent<Balloon>();
		balloonFive = GameObject.Find("Balloon Floor Five").GetComponent<Balloon>();
		balloonSeven = GameObject.Find("Balloon Floor Seven").GetComponent<Balloon>();
		dog = GameObject.Find("Doki").GetComponent<Dog>();
		keys = GameObject.Find("Keys").GetComponent<Keys>();
		door = GameObject.Find("Door").GetComponent<Door>();
		adManager = GameObject.Find("AdManager").GetComponent<AdManager>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Kitchen () {

		count++;

		if (count%3 == 0)
			adManager.ShowVideo();
		
		player.transform.position = posPlayer;
		player.currentPosition = posPlayer;
		player.actions = 0;
		player.direction = 1;

		juice.lvlNumber = 5;

		if(bowl.currentState != Bowl.BowlState.Empty) {
			
			bowl.spriteRender.color = bowl.alphaFullColor;
			bowl.currentState = Bowl.BowlState.Empty;
			playerBowl.SetActive(false);
			bowl.bowlShine.SetActive(false);

		}

		if (balloonSeven.currentState != Balloon.BallonState.Normal) {
			
			balloonSeven.currentState = Balloon.BallonState.Normal;
			balloonFive.currentState = Balloon.BallonState.Normal;
			balloonTwo.currentState = Balloon.BallonState.Normal;


		}

		balloonSeven.GetComponent<SpriteRenderer>().color = balloonSeven.alphaFullColor;
		balloonSeven.balloonFloorFive.GetComponent<SpriteRenderer>().color = balloonSeven.alphaZeroColor;
		balloonSeven.balloonFloorTwo.GetComponent<SpriteRenderer>().color = balloonSeven.alphaZeroColor;
		balloonSeven.balloonFloorFive.GetComponent<CircleCollider2D>().enabled = false;
		balloonSeven.balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = false;

		playerBalloon.SetActive(false);

		balloonTwo.shineFloorTwo.SetActive(false);
		balloonFive.shineFloorFive.SetActive(false);
		balloonSeven.shineFloorSeven.SetActive(false);


		dog.transform.position = posDog;
		dog.currentState = Dog.DogState.HasKeys;
		dog.spriteRender.sprite = dog.dogHasKeys;
		dog.spriteRender.sortingOrder = 30;
		dog.transform.localScale = new Vector3(1f,1f,1f);

		keys.spriteRender.color = keys.alphaZeroColor;
		playerKeys.SetActive(false);

		panel.SetActive(false);

	}

	public void WithGameOver () {
		
		player.transform.position = posPlayer;
		player.currentPosition = posPlayer;
		player.actions = 0;
		player.direction = 1;

		juice.lvlNumber = 5;

		if(bowl.currentState != Bowl.BowlState.Empty) {

			bowl.spriteRender.color = bowl.alphaFullColor;
			bowl.currentState = Bowl.BowlState.Empty;
			playerBowl.SetActive(false);
			bowl.bowlShine.SetActive(false);

		}


		if (balloonSeven.currentState != Balloon.BallonState.Normal) {

			balloonSeven.currentState = Balloon.BallonState.Normal;
			balloonFive.currentState = Balloon.BallonState.Normal;
			balloonTwo.currentState = Balloon.BallonState.Normal;


		}

		balloonSeven.GetComponent<SpriteRenderer>().color = balloonSeven.alphaFullColor;
		balloonSeven.balloonFloorFive.GetComponent<SpriteRenderer>().color = balloonSeven.alphaZeroColor;
		balloonSeven.balloonFloorTwo.GetComponent<SpriteRenderer>().color = balloonSeven.alphaZeroColor;
		balloonSeven.balloonFloorFive.GetComponent<CircleCollider2D>().enabled = false;
		balloonSeven.balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = false;

		playerBalloon.SetActive(false);

		balloonTwo.shineFloorTwo.SetActive(false);
		balloonFive.shineFloorFive.SetActive(false);
		balloonSeven.shineFloorSeven.SetActive(false);

		dog.dogCount = 0;
		dog.transform.position = posDog;
		dog.currentState = Dog.DogState.HasKeys;
		dog.spriteRender.sprite = dog.dogHasKeys;
		dog.spriteRender.sortingOrder = 30;
		dog.transform.localScale = new Vector3(1f,1f,1f);

		keys.spriteRender.color = keys.alphaZeroColor;
		playerKeys.SetActive(false);

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
			g.GetComponent<PolygonCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
			g.GetComponent<BoxCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Keys")) {
			g.GetComponent<BoxCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Bowl")) {
			g.GetComponent<BoxCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonSeven")) {
			g.GetComponent<CircleCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonFive")) {
			g.GetComponent<CircleCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonTwo")) {
			g.GetComponent<CircleCollider2D>().enabled = true;
		}

		player.musicBg.SetActive(true);

		panel.SetActive(false);

	}

	public void WithWinner () {

		player.transform.position = posPlayer;
		player.currentPosition = posPlayer;
		player.actions = 0;
		player.direction = 1;

		juice.lvlNumber = 5;

		if (balloonSeven.currentState != Balloon.BallonState.Normal) {

			balloonSeven.currentState = Balloon.BallonState.Normal;
			balloonFive.currentState = Balloon.BallonState.Normal;
			balloonTwo.currentState = Balloon.BallonState.Normal;


		}

		balloonSeven.GetComponent<SpriteRenderer>().color = balloonSeven.alphaFullColor;
		balloonSeven.balloonFloorFive.GetComponent<SpriteRenderer>().color = balloonSeven.alphaZeroColor;
		balloonSeven.balloonFloorTwo.GetComponent<SpriteRenderer>().color = balloonSeven.alphaZeroColor;
		balloonSeven.balloonFloorFive.GetComponent<CircleCollider2D>().enabled = false;
		balloonSeven.balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = false;

		playerBalloon.SetActive(false);

		balloonTwo.shineFloorTwo.SetActive(false);
		balloonFive.shineFloorFive.SetActive(false);
		balloonSeven.shineFloorSeven.SetActive(false);


		dog.transform.position = posDog;
		dog.currentState = Dog.DogState.HasKeys;
		dog.spriteRender.sprite = dog.dogHasKeys;
		dog.spriteRender.sortingOrder = 30;
		dog.transform.localScale = new Vector3(1f,1f,1f);

		keys.spriteRender.color = keys.alphaZeroColor;
		playerKeys.SetActive(false);

		if (door.spriteRender.sprite == door.doorOpened) {
			door.spriteRender.sprite = door.doorClosed;
		}


		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Floor")) {
			g.GetComponent<PolygonCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Touchable")) {
			g.GetComponent<BoxCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Keys")) {
			g.GetComponent<BoxCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Bowl")) {
			g.GetComponent<BoxCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonSeven")) {
			g.GetComponent<CircleCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonFive")) {
			g.GetComponent<CircleCollider2D>().enabled = true;
		}

		foreach(GameObject g in GameObject.FindGameObjectsWithTag("BalloonTwo")) {
			g.GetComponent<CircleCollider2D>().enabled = true;
		}

		player.musicBg.SetActive(true);

		panel.SetActive(false);

	}
}
