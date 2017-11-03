using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	Toy floorSix, couchOne, couchTwo, couchThree;
	Televisor tv;
	Radio radio;
	Mail mail;
	MailKeeper mk;

	Vector3 posPlayer = new Vector3 (-4.233907f, -3.727f, 0);
	Vector3 posDog = new Vector3 (-2.78f, -1.46f, 0);

	int count = 0;

	// Use this for initialization
	void Start () {

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		if (sceneName == "Kitchen") {

			Vector3 posPlayer = new Vector3 (-4.233907f, -3.727f, 0);
			Vector3 posDog = new Vector3 (-2.78f, -1.46f, 0);

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

		} else if ( sceneName == "LivinRoom") {

			posPlayer = new Vector3 (-4.233907f, -3.727f, 0);
			posDog = new Vector3 (-7.069908f, -4.22f, 0);

			player = GameObject.Find("Oki").GetComponent<Player>();
			juice = GameObject.Find("Juice").GetComponent<Juice>();
			dog = GameObject.Find("Doki").GetComponent<Dog>();
			door = GameObject.Find("Door").GetComponent<Door>();
			floorSix = GameObject.Find("Dog Toy").GetComponent<Toy>();
			couchOne = GameObject.Find("Couch 1").GetComponent<Toy>();
			couchTwo = GameObject.Find("Couch 2").GetComponent<Toy>();
			couchThree = GameObject.Find("Couch 3").GetComponent<Toy>();
			tv = GameObject.Find("TV").GetComponent<Televisor>();
			radio = GameObject.Find("Radio").GetComponent<Radio>();
			mail = GameObject.Find("Mail").GetComponent<Mail>();
			mk = GameObject.Find("Mail Keeper").GetComponent<MailKeeper>();
			adManager = GameObject.Find("AdManager").GetComponent<AdManager>();

		}



		
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

	public void LivingRoom () {

		player.transform.position = posPlayer;
		player.currentPosition = posPlayer;
		player.actions = 0;
		player.direction = 1;

		juice.lvlNumber = 5;

		if(tv.spriteRender.sprite == tv.tvOn) {
			tv.spriteRender.sprite = tv.tvOff;
		}

		if(floorSix.currentState != Toy.ToyState.Normal) {
			
			floorSix.currentState = Toy.ToyState.Normal;
			couchOne.currentState = Toy.ToyState.Normal;
			couchTwo.currentState = Toy.ToyState.Normal;
			couchThree.currentState = Toy.ToyState.Normal;


		}

		floorSix.GetComponent<SpriteRenderer>().color = floorSix.alphaFullColor;
		couchOne.GetComponent<SpriteRenderer>().color = couchOne.alphaZeroColor;
		couchTwo.GetComponent<SpriteRenderer>().color = couchTwo.alphaZeroColor;
		couchThree.GetComponent<SpriteRenderer>().color = couchThree.alphaZeroColor;

		floorSix.GetComponent<BoxCollider2D>().enabled = true;
		couchOne.GetComponent<BoxCollider2D>().enabled = false;
		couchTwo.GetComponent<BoxCollider2D>().enabled = false;
		couchThree.GetComponent<BoxCollider2D>().enabled = false;

		floorSix.shineCouchOne.SetActive(false);
		floorSix.shineCouchTwo.SetActive(false);
		floorSix.shineCouchThree.SetActive(false);
		floorSix.shineFloorSix.SetActive(false);

		couchOne.shineCouchOne.SetActive(false);
		couchOne.shineCouchTwo.SetActive(false);
		couchOne.shineCouchThree.SetActive(false);
		couchOne.shineFloorSix.SetActive(false);

		couchTwo.shineCouchOne.SetActive(false);
		couchTwo.shineCouchTwo.SetActive(false);
		couchTwo.shineCouchThree.SetActive(false);
		couchTwo.shineFloorSix.SetActive(false);

		couchThree.shineCouchOne.SetActive(false);
		couchThree.shineCouchTwo.SetActive(false);
		couchThree.shineCouchThree.SetActive(false);
		couchThree.shineFloorSix.SetActive(false);




		if(radio.musicNotes.activeSelf) {
			
			radio.musicNotes.SetActive(false);

			radio.sleepyMusic.Stop();
			radio.couchOneMusic.Stop();
			radio.couchTwoMusic.Stop();
			radio.bgMusic.Stop();

			radio.musicBackground.SetActive(true);
		}

		dog.isDoorOpen = false;
		dog.yappingPlayed = false;
		dog.sleepySound.Stop();
		dog.transform.position = posDog;
		dog.currentState = Dog.DogState.HasMail;
		dog.spriteRender.sprite = dog.dogHasMail;
		dog.spriteRender.sortingOrder = 30;
		dog.transform.localScale = new Vector3(1f,1f,1f);

		player.playerToy.SetActive(false);
		player.playerMail.SetActive(false);

		if(door.spriteRender.sprite == door.doorOpenedMail) {
			door.spriteRender.sprite = door.doorClosedMail;
		}

		mail.GetComponent<SpriteRenderer>().color = mail.alphaFullColor;
		mail.GetComponent<BoxCollider2D>().enabled = true;

		if(mk.spriteRender.sprite == mk.mailKeeperFull) {
			mk.spriteRender.sprite = mk.mailKeeperEmpty;
		}

		radio.musicBackground.SetActive(true);
		panel.SetActive(false);
		GameObject.Find("Looser Sound").GetComponent<AudioSource>().Stop();

	}

}
