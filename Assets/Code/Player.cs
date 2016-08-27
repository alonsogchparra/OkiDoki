using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum PlayerState { Happy, Normal, Dizzy, Sleepy }

	public PlayerState currentState = PlayerState.Happy;
	public Sprite okiHappy, okiNormal, okiDizzy, okiSleepy;
	public bool _isFacingRight;
	public float speed = 2.0f;
	public bool canMove;
	public Vector3 currentPosition;
	public Juice juice;
	public Sprite bowlEmpty, bowlFood, bowlWater;
	public SpriteRenderer bowlSpriteRender;
	public GameObject playerBalloon;

	private SpriteRenderer spriteRender;
	private DogFood dogFood;
	private Bowl bowl;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();
		dogFood = GameObject.Find("Dog Food").GetComponent<DogFood>();
		bowl = GameObject.Find("Bowl").GetComponent<Bowl>();

		if(spriteRender.sprite == null || currentState == PlayerState.Happy) {
			spriteRender.sprite = okiHappy;
		}

		if(bowlSpriteRender.sprite == null) {
			spriteRender.sprite = bowlEmpty;
		}

		currentPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		switch(juice.lvlNumber) {

		case 5:
			currentState = PlayerState.Happy;
			spriteRender.sprite = okiHappy;
			break;

		case 4:
			currentState = PlayerState.Happy;
			spriteRender.sprite = okiHappy;
			break;
		
		case 3:
			currentState = PlayerState.Normal;
			spriteRender.sprite = okiNormal;
			break;

		case 2:
			currentState = PlayerState.Normal;
			spriteRender.sprite = okiNormal;
			break;

		case 1:
			currentState = PlayerState.Dizzy;
			spriteRender.sprite = okiDizzy;
			break;

		
		case 0:
			currentState = PlayerState.Sleepy;
			spriteRender.sprite = okiSleepy;
			break;

		default:
			print("Nothing to do Here!!!");
			break;

		}

		if(currentPosition != transform.position && canMove) {

			MoveTowards(currentPosition);

		} else if (!canMove) {
			return;
		}

		if(juice.lvlNumber < 0)
			juice.lvlNumber = 0;
	}

	public void Flip() {
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	public void MoveTowards(Vector3 target) {

		_isFacingRight = transform.localScale.x > 0;

		if(_isFacingRight) {
			Flip();
		}

		transform.position = Vector3.MoveTowards(
			transform.position, 
			target, 
			Time.deltaTime * speed );
	}


	public void ChangeBowlSprite(){
		if(bowlSpriteRender.sprite == bowlEmpty && dogFood.canFeedDog) {
			bowlSpriteRender.sprite = bowlFood;
			bowl.currentState = Bowl.BowlState.SignFood;

		}
	}

}
