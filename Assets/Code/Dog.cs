using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

	public enum DogState { Happy, HasKeys, HasBalloon, Surprise, Eating, Drinking, Walking, FindingBallon }

	public DogState currentState = DogState.HasKeys;

	public Sprite dogHappy, dogHasKeys, dogHasBalloon, dogSurprise, dogEating, dogWalking, dogFindingBallon;

	public bool _isFacingRight;
	public float speed = 2.0f;

	public int dogCount = 0;

	private Bowl bowl;
	private Balloon balloon;
	private SpriteRenderer spriteRender;
//	private Player player;
//	private Floor floor;
	private Keys keys;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();
		bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
		balloon = GameObject.Find("Balloon Floor Seven").GetComponent<Balloon>();
//		player = GameObject.Find("Oki").GetComponent<Player>();
//		floor = GameObject.Find("Floor 1").GetComponent<Floor>();
		keys = GameObject.Find("Keys").GetComponent<Keys>();

		_isFacingRight = transform.localScale.x > 0;

		if(spriteRender == null || currentState == DogState.HasKeys)
			spriteRender.sprite = dogHasKeys;
	
	}
	
	// Update is called once per frame
	void Update () {

		//TODO: DEPENDE DONDE EL PERRO DEJE EL BALON, QUEDA ACTIVO PARA VOLVERLO AGARRAR

		if(dogCount == 2) {
			
			balloon.currentState = Balloon.BallonState.Normal;
			balloon.balloonFloorFive.GetComponent<Balloon>().currentState = Balloon.BallonState.Normal;
			balloon.balloonFloorTwo.GetComponent<Balloon>().currentState = Balloon.BallonState.Normal;

		} else if(dogCount == 3) {
			bowl.currentState = Bowl.BowlState.Empty;
		}


		if(bowl.currentState == Bowl.BowlState.Food || bowl.currentState == Bowl.BowlState.Water) {
			DogMoveToBowl();
		} else if (bowl.currentState == Bowl.BowlState.Empty && dogCount == 3) {
			DogMoveToKeys();
		
		} else if(balloon.currentState == Balloon.BallonState.Wanted 
			&& balloon.balloonFloorSeven.GetComponent<SpriteRenderer>().color == balloon.alphaFullColor) {

			currentState = DogState.FindingBallon;
			DogMoveToBalloon(balloon.balloonFloorSeven.transform.position);


		} else if(balloon.balloonFloorFive.GetComponent<Balloon>().currentState == Balloon.BallonState.Wanted 
			&& balloon.balloonFloorFive.GetComponent<SpriteRenderer>().color == balloon.alphaFullColor) {

			currentState = DogState.FindingBallon;
			DogMoveToBalloon(balloon.balloonFloorFive.transform.position);

		} else if (balloon.balloonFloorTwo.GetComponent<Balloon>().currentState == Balloon.BallonState.Wanted 
			&& balloon.balloonFloorTwo.GetComponent<SpriteRenderer>().color == balloon.alphaFullColor) {

			currentState = DogState.FindingBallon;
			DogMoveToBalloon(balloon.balloonFloorTwo.transform.position);

		}

		if(dogCount == 2 && currentState == DogState.HasBalloon) {
			BalloonToKeys(keys.transform.position);
		}
	}


	public void Flip() {
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}


	void DogMoveToBowl() {

		if(currentState == DogState.Walking) {
			spriteRender.sprite = dogWalking;	
		}

		var target = bowl.transform.position;
		target.y = transform.position.y;
		target.z = transform.position.z;

		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

		if(transform.position.x == target.x) {
			
			spriteRender.sprite = dogEating;
			currentState = DogState.Eating;

		} else if (transform.position.x != target.x) {
			
			spriteRender.sprite = dogWalking;
			transform.localScale = new Vector3(1f, 1f, 1f);
			currentState = DogState.Walking;
		}
	}

	void DogMoveToBalloon(Vector3 target) {

		if(currentState == DogState.FindingBallon) {
			spriteRender.sprite = dogFindingBallon;
		}
			

		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

		if(balloon.gameObject.tag == "BalloonSeven" || balloon.gameObject.tag == "BallooFive"){
			transform.localScale = new Vector3(1f,1f,1f);
		}else if(balloon.tag == "BalloonTwo"){
			transform.localScale = new Vector3(-1f,1f,1f);
		}

		if(transform.position.x == target.x) {
			
			spriteRender.sprite = dogHasBalloon;
			currentState = DogState.HasBalloon;

		} else if(transform.position.x != target.x) {
			
			currentState = DogState.Walking;
			spriteRender.sortingOrder = 50;
		}
	}

	void BalloonToKeys(Vector3 start) {

		if(currentState == DogState.HasBalloon) {
			spriteRender.sprite = dogFindingBallon;
		}

		if(transform.position.x == balloon.balloonFloorTwo.transform.position.x) {
			balloon.balloonFloorTwo.GetComponent<SpriteRenderer>().color = balloon.alphaFullColor;

		} else if(transform.position.x == balloon.balloonFloorFive.transform.position.x) {
			balloon.balloonFloorFive.GetComponent<SpriteRenderer>().color = balloon.alphaFullColor;

		} else if(transform.position.x == balloon.balloonFloorSeven.transform.position.x) {
			balloon.balloonFloorSeven.GetComponent<SpriteRenderer>().color = balloon.alphaFullColor;
		}

		transform.position = Vector3.MoveTowards(transform.position, start, Time.deltaTime * speed);


		if(balloon.gameObject.tag == "BalloonSeven" || balloon.gameObject.tag == "BallooFive"){
			transform.localScale = new Vector3(-1f,1f,1f);
		}else if(balloon.tag == "BalloonTwo"){
			transform.localScale = new Vector3(1f,1f,1f);
		}


		if(transform.position == keys.transform.position 
			&& keys.spriteRender.color == keys.alphaFullColor) {
			
			spriteRender.sprite = dogHasKeys;
			currentState = DogState.HasKeys;
//			balloon.balloonFloorTwo.GetComponent<Balloon>().currentState = Balloon.BallonState.Normal;
			dogCount = 0;

		} else if(transform.position.x == keys.transform.position.x 
			&& keys.spriteRender.color == keys.alphaZeroColor) {

			spriteRender.sprite = dogSurprise;

		} else if (transform.position.x != keys.transform.position.x) {
			
			currentState = DogState.Walking;
			spriteRender.sortingOrder = 30;
		}

	}

	void DogMoveToKeys() {

		if(currentState == DogState.Walking) {
			spriteRender.sprite = dogWalking;
		}

		var target = keys.transform.position;
		target.y = transform.position.y;
		target.z = transform.position.z;

		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

		if(transform.position.x == target.x && keys.spriteRender.color == keys.alphaFullColor) {

			spriteRender.sprite = dogHasKeys;
			currentState = DogState.HasKeys;
			dogCount = 0;

		} else if (transform.position.x == target.x && keys.spriteRender.color == keys.alphaZeroColor) {
			spriteRender.sprite = dogSurprise;

		} else if (transform.position.x != target.x) {

			spriteRender.sprite = dogWalking;
			transform.localScale = new Vector3(-1f, 1f, 1f);
			currentState = DogState.Walking;
		}

	}

}
