using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour {

	public enum ToyState { Normal, Picked, Wanted }
	public enum MouseOverType { CouchOne, CouchTwo, CouchThree, FloorSix }

	public MouseOverType mouseOverType;
	public ToyState currentState = ToyState.Normal;
	public GameObject shineCouchOne, shineCouchTwo, shineCouchThree, shineFloorSix;

	public bool canTakeIt;
	public Sprite toy, spriteShine, spriteCannot;
	public GameObject couchOne, couchTwo, couchThree, floorSix;
	public AudioSource cannotSound, toySound;

	[HideInInspector]
	public Color alphaHalfColor, alphaFullColor, alphaZeroColor;

	private Player player;
	private SpriteRenderer sr_couchOne, sr_couchTwo, sr_couchThree, sr_floorSix;
	private Dog dog;
	private Juice juice;
	private Mail mail;

	// Use this for initialization
	void Start () {

		mouseOverType = MouseOverType.FloorSix;

		player = GameObject.Find("Oki").GetComponent<Player>();
		dog = GameObject.Find("Doki").GetComponent<Dog>();
		juice = GameObject.Find("Juice").GetComponent<Juice>();
		mail = GameObject.Find("Mail").GetComponent<Mail>();

		sr_floorSix = GetComponent<SpriteRenderer>();
		sr_couchOne = gameObject.GetComponent<SpriteRenderer>();
		sr_couchTwo = gameObject.GetComponent<SpriteRenderer>();
		sr_couchThree = gameObject.GetComponent<SpriteRenderer>();

		if (sr_floorSix == null && sr_couchOne == null && sr_couchTwo == null && sr_couchThree == null) {
			
			sr_floorSix.sprite = toy;
			sr_couchOne.sprite = toy;
			sr_couchTwo.sprite = toy;
			sr_couchThree.sprite = toy;

		}

		alphaFullColor = sr_floorSix.color;
		alphaFullColor.a = 1f;
		alphaHalfColor = sr_floorSix.color;
		alphaHalfColor.a = 0.5f;
		alphaZeroColor = sr_floorSix.color;
		alphaZeroColor.a = 0f;

		couchOne.GetComponent<BoxCollider2D>().enabled = false;
		couchTwo.GetComponent<BoxCollider2D>().enabled = false;
		couchThree.GetComponent<BoxCollider2D>().enabled = false;

		
	}
	
	// Update is called once per frame
	void Update () {

		if (dog.currentState == Dog.DogState.WatchTV) {
			canTakeIt = false;
		} else if (player.transform.position.x == GameObject.Find("Floor 3").transform.position.x
			&& couchOne.GetComponent<SpriteRenderer>().color == alphaFullColor
			&& !player.playerMail.activeSelf) {
			canTakeIt = true;
		} else if (player.transform.position.x == GameObject.Find("Floor 4").transform.position.x
			&& couchTwo.GetComponent<SpriteRenderer>().color == alphaFullColor
			&& !player.playerMail.activeSelf) {
			canTakeIt = true;
		} else if (player.transform.position.x == GameObject.Find("Floor 6").transform.position.x
			&& floorSix.GetComponent<SpriteRenderer>().color == alphaFullColor
			&& !player.playerMail.activeSelf) {
			canTakeIt = true;
		} else if (player.transform.position.x == GameObject.Find("Floor 6").transform.position.x
			&& couchThree.GetComponent<SpriteRenderer>().color == alphaFullColor
			&& !player.playerMail.activeSelf) {
			canTakeIt = true;
		} else if (player.transform.position.x == GameObject.Find("Floor 3").transform.position.x
			&& couchOne.GetComponent<SpriteRenderer>().color == alphaFullColor
			&& currentState == ToyState.Normal && !player.playerMail.activeSelf) {
			canTakeIt = true;
		} else if (player.transform.position.x == GameObject.Find("Floor 4").transform.position.x
			&& couchTwo.GetComponent<SpriteRenderer>().color == alphaFullColor
			&& currentState == ToyState.Normal && !player.playerMail.activeSelf) {
			canTakeIt = true;
		} else if (player.transform.position.x == GameObject.Find("Floor 6").transform.position.x
			&& floorSix.GetComponent<SpriteRenderer>().color == alphaFullColor
			&& currentState == ToyState.Normal && !player.playerMail.activeSelf) {
			canTakeIt = true;
		} else if (player.transform.position.x == GameObject.Find("Floor 6").transform.position.x
			&& couchThree.GetComponent<SpriteRenderer>().color == alphaFullColor
			&& currentState == ToyState.Normal && !player.playerMail.activeSelf) {
			canTakeIt = true;
		} else {
			canTakeIt = false;
		}

		if( player.transform.position.x == GameObject.Find("Floor 3").transform.position.x) {
			mouseOverType = MouseOverType.CouchOne;
		} else if (player.transform.position.x == GameObject.Find("Floor 4").transform.position.x) {
			mouseOverType = MouseOverType.CouchTwo;
		} else if (player.transform.position.x == GameObject.Find("Floor 6").transform.position.x 
			&& floorSix.GetComponent<SpriteRenderer>().color == alphaFullColor 
			&& couchThree.GetComponent<SpriteRenderer>().color == alphaZeroColor) {
		
			mouseOverType = MouseOverType.FloorSix;

		} else if (player.transform.position.x == GameObject.Find("Floor 6").transform.position.x
			&& couchThree.GetComponent<SpriteRenderer>().color == alphaFullColor 
			&& floorSix.GetComponent<SpriteRenderer>().color == alphaZeroColor) {

			mouseOverType = MouseOverType.CouchThree;
		}

		if (dog.currentState == Dog.DogState.HasToy 
			&& dog.transform.position.x == floorSix.transform.position.x) {

			couchOne.GetComponent<BoxCollider2D>().enabled = false;
			couchTwo.GetComponent<BoxCollider2D>().enabled = false;
			couchThree.GetComponent<BoxCollider2D>().enabled = false;

		} else if (dog.currentState == Dog.DogState.HasToy 
			&& dog.transform.position.x == couchOne.transform.position.x) {

			floorSix.GetComponent<BoxCollider2D>().enabled = false;
			couchTwo.GetComponent<BoxCollider2D>().enabled = false;
			couchThree.GetComponent<BoxCollider2D>().enabled = false;

		}  else if (dog.currentState == Dog.DogState.HasToy 
			&& dog.transform.position.x == couchTwo.transform.position.x) {

			couchOne.GetComponent<BoxCollider2D>().enabled = false;
			floorSix.GetComponent<BoxCollider2D>().enabled = false;
			couchThree.GetComponent<BoxCollider2D>().enabled = false;

		} else if (dog.currentState == Dog.DogState.HasToy 
			&& dog.transform.position.x == couchThree.transform.position.x) {

			couchOne.GetComponent<BoxCollider2D>().enabled = false;
			couchTwo.GetComponent<BoxCollider2D>().enabled = false;
			floorSix.GetComponent<BoxCollider2D>().enabled = false;
		}

		switch(currentState) {

		case ToyState.Picked:
			shineCouchOne.SetActive(true);
			shineCouchTwo.SetActive(true);
			shineCouchThree.SetActive(true);
			shineFloorSix.SetActive(true);
			canTakeIt = false;
			break;

		case ToyState.Wanted:
			shineCouchOne.SetActive(true);
			shineCouchTwo.SetActive(true);
			shineCouchThree.SetActive(true);
			shineFloorSix.SetActive(true);
			canTakeIt = false;
			break;

		default:
			break;

		}

		if (dog.transform.position == floorSix.transform.position) {
			
			shineFloorSix.SetActive(false);
			floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

		} else if (dog.transform.position == couchOne.transform.position) {

			shineCouchOne.SetActive(false);
			couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;

		} else if (dog.transform.position == couchTwo.transform.position) {

			shineCouchTwo.SetActive(false);
			couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;

		} else if (dog.transform.position == couchThree.transform.position) {

			shineCouchThree.SetActive(false);
			couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;

		}


		if(floorSix.GetComponent<Toy>().currentState == ToyState.Wanted) {
			
			shineCouchOne.SetActive(false);
			shineCouchTwo.SetActive(false);
			shineCouchThree.SetActive(false);

		} else if(couchOne.GetComponent<Toy>().currentState == ToyState.Wanted) {

			shineFloorSix.SetActive(false);
			shineCouchTwo.SetActive(false);
			shineCouchThree.SetActive(false);

		} else if(couchTwo.GetComponent<Toy>().currentState == ToyState.Wanted) {

			shineCouchOne.SetActive(false);
			shineFloorSix.SetActive(false);
			shineCouchThree.SetActive(false);

		} else if(couchThree.GetComponent<Toy>().currentState == ToyState.Wanted) {

			shineCouchOne.SetActive(false);
			shineCouchTwo.SetActive(false);
			shineFloorSix.SetActive(false);

		}

		
	}

	void OnMouseOver() {

		if(floorSix.GetComponent<SpriteRenderer>().color == alphaFullColor 
			&& gameObject.tag == "DogToy") {

			shineFloorSix.SetActive(true);

		} else if(couchOne.GetComponent<SpriteRenderer>().color == alphaFullColor 
			&& gameObject.tag == "CouchOne") {

			shineCouchOne.SetActive(true);

		} else if(couchTwo.GetComponent<SpriteRenderer>().color == alphaFullColor 
			&& gameObject.tag == "CouchTwo") {

			shineCouchTwo.SetActive(true);

		} else if(couchThree.GetComponent<SpriteRenderer>().color == alphaFullColor 
			&& gameObject.tag == "CouchThree") {

			shineCouchThree.SetActive(true);
		}

		switch(mouseOverType) {

		case MouseOverType.CouchOne:

			if (Input.GetMouseButtonDown(0) && player.playerMail.activeSelf) {

				shineFloorSix.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchOne.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchTwo.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchThree.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt
				&& couchOne.GetComponent<SpriteRenderer>().color == alphaFullColor) {

				shineCouchOne.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if(Input.GetMouseButtonDown(0) && canTakeIt) {

				toySound.Play();

				player.playerToy.SetActive(true);


				sr_couchOne.color = alphaHalfColor;
				couchOne.GetComponent<SpriteRenderer>().color = alphaHalfColor;

				floorSix.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				couchTwo.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaHalfColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = true;
				couchOne.GetComponent<BoxCollider2D>().enabled = true;
				couchTwo.GetComponent<BoxCollider2D>().enabled = true;
				couchThree.GetComponent<BoxCollider2D>().enabled = true;

				currentState = ToyState.Picked;
				floorSix.GetComponent<Toy>().currentState = ToyState.Picked;
				couchTwo.GetComponent<Toy>().currentState = ToyState.Picked;
				couchThree.GetComponent<Toy>().currentState = ToyState.Picked;

				shineFloorSix.SetActive(true);
				shineCouchOne.SetActive(true);
				shineCouchTwo.SetActive(true);
				shineCouchThree.SetActive(true);

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "DogToy") {

				player.playerToy.SetActive(false);

				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				couchOne.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				sr_floorSix.color = alphaFullColor;
				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchOne") {

				player.playerToy.SetActive(false);

				couchOne.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchTwo") {

				player.playerToy.SetActive(false);

				couchTwo.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchOne.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchThree") {

				player.playerToy.SetActive(false);

				couchThree.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchOne.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "DogToy") {

				shineFloorSix.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchOne") {

				shineCouchOne.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();


			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchTwo") {

				shineCouchTwo.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchThree") {

				shineCouchThree.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			}

			break;

		case MouseOverType.CouchTwo:

			if (Input.GetMouseButtonDown(0) && player.playerMail.activeSelf) {

				shineFloorSix.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchOne.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchTwo.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchThree.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt
				&& couchTwo.GetComponent<SpriteRenderer>().color == alphaFullColor) {

				shineCouchTwo.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if(Input.GetMouseButtonDown(0) && canTakeIt) {

				toySound.Play();

				player.playerToy.SetActive(true);


				sr_couchTwo.color = alphaHalfColor;
				couchTwo.GetComponent<SpriteRenderer>().color = alphaHalfColor;

				floorSix.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				couchOne.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaHalfColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = true;
				couchOne.GetComponent<BoxCollider2D>().enabled = true;
				couchTwo.GetComponent<BoxCollider2D>().enabled = true;
				couchThree.GetComponent<BoxCollider2D>().enabled = true;

				currentState = ToyState.Picked;
				floorSix.GetComponent<Toy>().currentState = ToyState.Picked;
				couchTwo.GetComponent<Toy>().currentState = ToyState.Picked;
				couchThree.GetComponent<Toy>().currentState = ToyState.Picked;

				shineFloorSix.SetActive(true);
				shineCouchOne.SetActive(true);
				shineCouchTwo.SetActive(true);
				shineCouchThree.SetActive(true);

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "DogToy") {

				player.playerToy.SetActive(false);

				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				couchOne.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				sr_floorSix.color = alphaFullColor;
				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchOne") {

				player.playerToy.SetActive(false);

				couchOne.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());


			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchTwo") {

				player.playerToy.SetActive(false);

				couchTwo.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchOne.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());


			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchThree") {

				player.playerToy.SetActive(false);

				couchThree.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchOne.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "DogToy") {

				shineFloorSix.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchOne") {

				shineCouchOne.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();


			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchTwo") {

				shineCouchTwo.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchThree") {

				shineCouchThree.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			}

			break;
		
		case MouseOverType.CouchThree:


			if (Input.GetMouseButtonDown(0) && player.playerMail.activeSelf) {

				shineFloorSix.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchOne.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchTwo.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchThree.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt
				&& couchThree.GetComponent<SpriteRenderer>().color == alphaFullColor) {

				shineCouchThree.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if(Input.GetMouseButtonDown(0) && canTakeIt) {

				toySound.Play();

				player.playerToy.SetActive(true);


				sr_couchThree.color = alphaHalfColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaHalfColor;

				floorSix.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				couchOne.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				couchTwo.GetComponent<SpriteRenderer>().color = alphaHalfColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = true;
				couchOne.GetComponent<BoxCollider2D>().enabled = true;
				couchTwo.GetComponent<BoxCollider2D>().enabled = true;
				couchThree.GetComponent<BoxCollider2D>().enabled = true;

				currentState = ToyState.Picked;
				floorSix.GetComponent<Toy>().currentState = ToyState.Picked;
				couchOne.GetComponent<Toy>().currentState = ToyState.Picked;
				couchTwo.GetComponent<Toy>().currentState = ToyState.Picked;
				couchThree.GetComponent<Toy>().currentState = ToyState.Picked;

				shineFloorSix.SetActive(true);
				shineCouchOne.SetActive(true);
				shineCouchTwo.SetActive(true);
				shineCouchThree.SetActive(true);

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "DogToy") {

				player.playerToy.SetActive(false);

				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				couchOne.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				sr_floorSix.color = alphaFullColor;
				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchOne") {

				player.playerToy.SetActive(false);

				couchOne.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());


			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchTwo") {

				player.playerToy.SetActive(false);

				couchTwo.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchOne.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());


			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchThree") {

				player.playerToy.SetActive(false);

				couchThree.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchOne.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "DogToy") {

				shineFloorSix.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchOne") {

				shineCouchOne.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();


			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchTwo") {

				shineCouchTwo.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchThree") {

				shineCouchThree.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			}


			break;

		case MouseOverType.FloorSix:

			if (Input.GetMouseButtonDown(0) && player.playerMail.activeSelf) {

				shineFloorSix.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchOne.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchTwo.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				shineCouchThree.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if (Input.GetMouseButtonDown(0) && !canTakeIt
				&& floorSix.GetComponent<SpriteRenderer>().color == alphaFullColor) {

				shineFloorSix.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if(Input.GetMouseButtonDown(0) && canTakeIt) {

				//Toy Sound
				toySound.Play();

				player.playerToy.SetActive(true);


				sr_floorSix.color = alphaHalfColor;

				couchOne.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				couchTwo.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaHalfColor;

				couchOne.GetComponent<BoxCollider2D>().enabled = true;
				couchTwo.GetComponent<BoxCollider2D>().enabled = true;
				couchThree.GetComponent<BoxCollider2D>().enabled = true;

				currentState = ToyState.Picked;
				couchOne.GetComponent<Toy>().currentState = ToyState.Picked;
				couchTwo.GetComponent<Toy>().currentState = ToyState.Picked;
				couchThree.GetComponent<Toy>().currentState = ToyState.Picked;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "DogToy") {

				player.playerToy.SetActive(false);

				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				couchOne.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				sr_floorSix.color = alphaFullColor;
				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchOne") {

				player.playerToy.SetActive(false);

				couchOne.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());


			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchTwo") {

				player.playerToy.SetActive(false);

				couchTwo.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchThree.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchOne.GetComponent<BoxCollider2D>().enabled = false;
				couchThree.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());
				

			} else if(Input.GetMouseButtonDown(0)
				&& currentState == ToyState.Picked && gameObject.tag == "CouchThree") {

				player.playerToy.SetActive(false);

				couchThree.GetComponent<SpriteRenderer>().color = alphaFullColor;

				couchTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				couchOne.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				floorSix.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				floorSix.GetComponent<BoxCollider2D>().enabled = false;
				couchTwo.GetComponent<BoxCollider2D>().enabled = false;
				couchOne.GetComponent<BoxCollider2D>().enabled = false;

				currentState = ToyState.Wanted;

				juice.lvlNumber--;
				player.actions++;

				if (juice.lvlNumber < 1)
					StartCoroutine(player.GameOver());
				
			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "DogToy") {

				shineFloorSix.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();
				
			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchOne") {

				shineCouchOne.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

				
			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchTwo") {

				shineCouchTwo.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();
				
			} else if (Input.GetMouseButtonDown(0) && !canTakeIt && gameObject.tag == "CouchThree") {

				shineCouchThree.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			}

			break;

		default:
			break;

		}
		
	}



	void OnMouseExit() {

		shineFloorSix.SetActive(false);
		shineCouchOne.SetActive(false);
		shineCouchTwo.SetActive(false);
		shineCouchThree.SetActive(false);

		shineFloorSix.GetComponent<SpriteRenderer>().sprite = spriteShine;
		shineCouchOne.GetComponent<SpriteRenderer>().sprite = spriteShine;
		shineCouchTwo.GetComponent<SpriteRenderer>().sprite = spriteShine;
		shineCouchThree.GetComponent<SpriteRenderer>().sprite = spriteShine;


	}
}
