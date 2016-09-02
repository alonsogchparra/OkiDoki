using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	public enum BallonState { Normal, Picked, Wanted }
	public enum MouseOverType { FloorTwo, FloorFive, FloorSeven }

	public MouseOverType mouseOverType;
	public BallonState currentState = BallonState.Normal;
	public GameObject shineFloorTwo, shineFloorFive, shineFloorSeven, playerBalloon;

	public bool canTakeIt;
	public Sprite balloon;

	public GameObject balloonFloorTwo, balloonFloorFive, balloonFloorSeven;

	[HideInInspector]
	public Color alphaHalfColor, alphaFullColor, alphaZeroColor;

	private Player player;
	private SpriteRenderer spriteRender, sr_balloonFloorFive, sr_ballooFloorTwo; 
	private Dog dog;
	private Juice juice;
	private Bowl bowl;


	// Use this for initialization
	void Start () {
	
		player = GameObject.Find("Oki").GetComponent<Player>();
		dog = GameObject.Find("Doki").GetComponent<Dog>();
		juice = GameObject.Find("Juice").GetComponent<Juice>();
		bowl = GameObject.Find("Bowl").GetComponent<Bowl>();

		spriteRender = GetComponent<SpriteRenderer>();
		sr_ballooFloorTwo = gameObject.GetComponent<SpriteRenderer>();
		sr_balloonFloorFive = gameObject.GetComponent<SpriteRenderer>();

		if(spriteRender == null && sr_balloonFloorFive == null && sr_ballooFloorTwo) {
			spriteRender.sprite = balloon;
			sr_balloonFloorFive.sprite = balloon;
			sr_ballooFloorTwo.sprite = balloon;
		}

		alphaHalfColor = spriteRender.color;
		alphaHalfColor.a = 0.5f;
		alphaFullColor = spriteRender.color;
		alphaFullColor.a = 1f;
		alphaZeroColor = spriteRender.color;
		alphaZeroColor.a = 0f;

	}

	void Update () {

//		if(player.transform.position.x == 7.14f 
//			|| player.transform.position.x == 0.36f 
//			|| player.transform.position.x == -4.47f) {
//
//			canTakeIt = true;
//		} else {
//			canTakeIt = false;
//		}


		if(player.transform.position.x == 7.14f 
			&& balloonFloorSeven.GetComponent<SpriteRenderer>().color == alphaFullColor 
			&& !bowl.playerBowl.activeSelf) {
			canTakeIt = true;
		}else if(player.transform.position.x == 0.36f 
			&& balloonFloorFive.GetComponent<SpriteRenderer>().color == alphaFullColor
			&& !bowl.playerBowl.activeSelf) {
			canTakeIt = true;
		} else if (player.transform.position.x == -4.47f 
			&& balloonFloorTwo.GetComponent<SpriteRenderer>().color == alphaFullColor 
			&& currentState == BallonState.Normal && !bowl.playerBowl.activeSelf) {
			canTakeIt = true;
		} else {
			canTakeIt = false;
		}

		if(player.transform.position.x == -4.47f) {
			mouseOverType = MouseOverType.FloorTwo;
		} else if (player.transform.transform.position.x == 0.36f) {
			mouseOverType = MouseOverType.FloorFive;
		} else if (player.transform.position.x == 7.14f) {
			mouseOverType = MouseOverType.FloorSeven;
		}

		switch(currentState) {

			case BallonState.Picked:
				shineFloorSeven.SetActive(true);
				shineFloorFive.SetActive(true);
				shineFloorTwo.SetActive(true);
				canTakeIt = false;
				break;

			case BallonState.Wanted:
				shineFloorSeven.SetActive(true);
				shineFloorFive.SetActive(true);
				shineFloorTwo.SetActive(true);
				canTakeIt = false;
				break;

			default:
				break;

		}

		if(dog.transform.position == balloonFloorSeven.transform.position) {
			
			shineFloorSeven.SetActive(false);
			balloonFloorSeven.GetComponent<SpriteRenderer>().color = alphaZeroColor;

		} else if(dog.transform.position == balloonFloorFive.transform.position) {
			
			shineFloorFive.SetActive(false);
			balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaZeroColor;

		} else if(dog.transform.position == balloonFloorTwo.transform.position) {
			
			shineFloorTwo.SetActive(false);
			balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;

		}



		if(balloonFloorSeven.GetComponent<Balloon>().currentState == BallonState.Wanted) {

			shineFloorTwo.SetActive(false);
			shineFloorFive.SetActive(false);

		} else if(balloonFloorFive.GetComponent<Balloon>().currentState == BallonState.Wanted) {

			shineFloorTwo.SetActive(false);
			shineFloorSeven.SetActive(false);

		} else if(balloonFloorTwo.GetComponent<Balloon>().currentState == BallonState.Wanted) {

			shineFloorFive.SetActive(false);
			shineFloorSeven.SetActive(false);

		}
	
	}

	void OnMouseOver(){

		if(balloonFloorTwo.GetComponent<SpriteRenderer>().color == alphaFullColor && gameObject.tag == "BalloonTwo") {
			shineFloorTwo.SetActive(true);
		} else if(balloonFloorFive.GetComponent<SpriteRenderer>().color == alphaFullColor && gameObject.tag == "BalloonFive") {
			shineFloorFive.SetActive(true);
		} else if(balloonFloorSeven.GetComponent<SpriteRenderer>().color == alphaFullColor && gameObject.tag == "BalloonSeven") {
			shineFloorSeven.SetActive(true);
		}


		switch(mouseOverType) {

		case MouseOverType.FloorTwo:

			if(Input.GetMouseButtonDown(0) && canTakeIt) {

				playerBalloon.SetActive(true);

				spriteRender.color = alphaHalfColor;
				sr_ballooFloorTwo.color = alphaHalfColor;

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				balloonFloorSeven.GetComponent<SpriteRenderer>().color = alphaHalfColor;

				balloonFloorFive.GetComponent<CircleCollider2D>().enabled = true;
				balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = true;
				balloonFloorSeven.GetComponent<CircleCollider2D>().enabled = true;

				balloonFloorFive.GetComponent<Balloon>().currentState = BallonState.Picked;
				balloonFloorTwo.GetComponent<Balloon>().currentState = BallonState.Picked;
				balloonFloorSeven.GetComponent<Balloon>().currentState = BallonState.Picked;

				shineFloorTwo.SetActive(true);
				shineFloorFive.SetActive(true);
				shineFloorSeven.SetActive(true);

				currentState = BallonState.Picked;

			}else if(Input.GetMouseButtonDown(0) 
				&& currentState == BallonState.Picked && gameObject.tag == "BalloonSeven") {

				playerBalloon.SetActive(false);

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				balloonFloorFive.GetComponent<CircleCollider2D>().enabled = false;
				balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = false;

				spriteRender.color = alphaFullColor;
				currentState = BallonState.Wanted;

			} else if (Input.GetMouseButtonDown(0) 
				&& currentState == BallonState.Picked && gameObject.tag == "BalloonFive") {

				playerBalloon.SetActive(false);

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaFullColor;

				balloonFloorSeven.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				balloonFloorSeven.GetComponent<CircleCollider2D>().enabled = false;
				balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = false;

				currentState = BallonState.Wanted;

			} else if (Input.GetMouseButtonDown(0) 
				&& currentState == BallonState.Picked && gameObject.tag == "BalloonTwo") {

				playerBalloon.SetActive(false);

				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaFullColor;

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				balloonFloorSeven.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				balloonFloorFive.GetComponent<CircleCollider2D>().enabled = false;
				balloonFloorSeven.GetComponent<CircleCollider2D>().enabled = false;

				currentState = BallonState.Wanted;

			}

			break;

		case MouseOverType.FloorFive:

			if(Input.GetMouseButtonDown(0) && canTakeIt) {

				playerBalloon.SetActive(true);

				spriteRender.color = alphaHalfColor;
				sr_ballooFloorTwo.color = alphaHalfColor;

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				balloonFloorSeven.GetComponent<SpriteRenderer>().color = alphaHalfColor;

				balloonFloorFive.GetComponent<CircleCollider2D>().enabled = true;
				balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = true;
				balloonFloorSeven.GetComponent<CircleCollider2D>().enabled = true;

				balloonFloorFive.GetComponent<Balloon>().currentState = BallonState.Picked;
				balloonFloorTwo.GetComponent<Balloon>().currentState = BallonState.Picked;
				balloonFloorSeven.GetComponent<Balloon>().currentState = BallonState.Picked;

				shineFloorTwo.SetActive(true);
				shineFloorFive.SetActive(true);
				shineFloorSeven.SetActive(true);

				currentState = BallonState.Picked;

			}else if(Input.GetMouseButtonDown(0) 
				&& currentState == BallonState.Picked && gameObject.tag == "BalloonSeven") {

				playerBalloon.SetActive(false);

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				balloonFloorFive.GetComponent<CircleCollider2D>().enabled = false;
				balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = false;

				spriteRender.color = alphaFullColor;
				currentState = BallonState.Wanted;
				juice.lvlNumber--;

			} else if (Input.GetMouseButtonDown(0) 
				&& currentState == BallonState.Picked && gameObject.tag == "BalloonFive") {

				playerBalloon.SetActive(false);

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaFullColor;

				balloonFloorSeven.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				balloonFloorSeven.GetComponent<CircleCollider2D>().enabled = false;
				balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = false;

				currentState = BallonState.Wanted;

				juice.lvlNumber--;

			} else if (Input.GetMouseButtonDown(0) 
				&& currentState == BallonState.Picked && gameObject.tag == "BalloonTwo") {

				playerBalloon.SetActive(false);

				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaFullColor;

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				balloonFloorSeven.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				balloonFloorFive.GetComponent<CircleCollider2D>().enabled = false;
				balloonFloorSeven.GetComponent<CircleCollider2D>().enabled = false;

				currentState = BallonState.Wanted;
				juice.lvlNumber--;
			}

			break;
		
		case MouseOverType.FloorSeven:

			if(Input.GetMouseButtonDown(0) && canTakeIt) {

				playerBalloon.SetActive(true);

				spriteRender.color = alphaHalfColor;
				sr_ballooFloorTwo.color = alphaHalfColor;

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaHalfColor;
				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaHalfColor;

				balloonFloorFive.GetComponent<CircleCollider2D>().enabled = true;
				balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = true;

				balloonFloorFive.GetComponent<Balloon>().currentState = BallonState.Picked;
				balloonFloorTwo.GetComponent<Balloon>().currentState = BallonState.Picked;
				currentState = BallonState.Picked;
				juice.lvlNumber--;

			}else if(Input.GetMouseButtonDown(0) 
				&& currentState == BallonState.Picked && gameObject.tag == "BalloonSeven") {

				playerBalloon.SetActive(false);

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				balloonFloorFive.GetComponent<CircleCollider2D>().enabled = false;
				balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = false;

				spriteRender.color = alphaFullColor;
				currentState = BallonState.Wanted;

			} else if (Input.GetMouseButtonDown(0) 
				&& currentState == BallonState.Picked && gameObject.tag == "BalloonFive") {

				playerBalloon.SetActive(false);

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaFullColor;

				balloonFloorSeven.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				balloonFloorSeven.GetComponent<CircleCollider2D>().enabled = false;
				balloonFloorTwo.GetComponent<CircleCollider2D>().enabled = false;

				currentState = BallonState.Wanted;

			} else if (Input.GetMouseButtonDown(0) 
				&& currentState == BallonState.Picked && gameObject.tag == "BalloonTwo") {

				playerBalloon.SetActive(false);

				balloonFloorTwo.GetComponent<SpriteRenderer>().color = alphaFullColor;

				balloonFloorFive.GetComponent<SpriteRenderer>().color = alphaZeroColor;
				balloonFloorSeven.GetComponent<SpriteRenderer>().color = alphaZeroColor;

				balloonFloorFive.GetComponent<CircleCollider2D>().enabled = false;
				balloonFloorSeven.GetComponent<CircleCollider2D>().enabled = false;

				currentState = BallonState.Wanted;

			}

			break;

			default:
			break;

		}

//		if(Input.GetMouseButtonDown(0) && canTakeIt) {
//			
//			playerBalloon.SetActive(true);
//			spriteRender.color = alphaHalfColor;
//			currentState = BallonState.Picked;
//
//		}else if(Input.GetMouseButtonDown(0) && currentState == BallonState.Picked) {
//			
//			playerBalloon.SetActive(false);
//			spriteRender.color = alphaFullColor;
//			currentState = BallonState.Wanted;
//
//		}

	}

	void OnMouseExit(){
		shineFloorSeven.SetActive(false);
		shineFloorFive.SetActive(false);
		shineFloorTwo.SetActive(false);
	}
}
