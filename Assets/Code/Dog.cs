using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

	public enum DogState { Happy, HasKeys, HasBalloon, Surprise, Eating, Drinking, Walking, FindingBallon }

	public DogState currentState = DogState.HasKeys;

	public Sprite dogHappy, dogHasKeys, dogHasBalloon, dogSurprise, dogEating, dogWalking, dogFindingBallon;

	public bool _isFacingRight;
	public float speed = 2.0f;

	private Bowl bowl;
	private SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {
		
		spriteRender = GetComponent<SpriteRenderer>();
		bowl = GameObject.Find("Bowl").GetComponent<Bowl>();

		if(spriteRender == null || currentState == DogState.HasKeys)
			spriteRender.sprite = dogHasKeys;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(bowl.currentState == Bowl.BowlState.Food) {
			DogMoveToBowl();
			currentState = DogState.Walking;
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


		
	}
}
