using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

	public enum DogState { Happy, HasKeys, HasBalloon, Surprise, Eating, Drinking, Walking, FindingBallon }

	public DogState currentState = DogState.HasKeys;

	public Sprite dogHappy, dogHasKeys, dogHasBalloon, dogSurprise, dogEating, dogWalking, dogFindingBallon;

	public bool _isFacingRight;
	public float speed = 2.0f;

	private Bowl bowl;
	private Balloon balloon;
	private SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();
		bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
		balloon = GameObject.Find("Balloon Floor Seven").GetComponent<Balloon>();

		if(spriteRender == null || currentState == DogState.HasKeys)
			spriteRender.sprite = dogHasKeys;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(bowl.currentState == Bowl.BowlState.Food || bowl.currentState == Bowl.BowlState.Water) {
			
			DogMoveToBowl();
			currentState = DogState.Walking;

			if(transform.position == bowl.transform.position) {
				currentState = DogState.Eating;
			}
		} else if(balloon.currentState == Balloon.BallonState.Wanted 
			&& balloon.balloonFloorSeven.GetComponent<SpriteRenderer>().color == balloon.alphaFullColor) {
			
			DogMoveToBalloon(balloon.balloonFloorSeven.transform.position);
			currentState = DogState.FindingBallon;

		} else if(balloon.balloonFloorFive.GetComponent<Balloon>().currentState == Balloon.BallonState.Wanted 
			&& balloon.balloonFloorFive.GetComponent<SpriteRenderer>().color == balloon.alphaFullColor) {

			DogMoveToBalloon(balloon.balloonFloorFive.transform.position);
			currentState = DogState.FindingBallon;

		} else if (balloon.balloonFloorTwo.GetComponent<Balloon>().currentState == Balloon.BallonState.Wanted 
			&& balloon.balloonFloorTwo.GetComponent<SpriteRenderer>().color == balloon.alphaFullColor) {

			DogMoveToBalloon(balloon.balloonFloorTwo.transform.position);
			currentState = DogState.FindingBallon;
		}
			
	
	}


	public void Flip() {
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}


	void DogMoveToBowl() {

		_isFacingRight = transform.localScale.x > 0;

		if(_isFacingRight) {
			Flip();
		}

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

		}
	}

	void DogMoveToBalloon(Vector3 target) {

		_isFacingRight = transform.localScale.x > 0;

		if(_isFacingRight) {
			Flip();
		}

		if(currentState == DogState.FindingBallon) {
			spriteRender.sprite = dogFindingBallon;
		}
			

		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

		if(transform.position == target) {
			spriteRender.sprite = dogHasBalloon;
			currentState = DogState.HasBalloon;
		}
	}
}
