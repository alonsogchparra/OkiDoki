using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

	public enum DogState { Happy, HasKeys, HasBalloon, Surprise, Eating, Drinking, Walking, FindingBallon }

	public DogState currentState = DogState.HasKeys;
	public Sprite dogHappy, dogHasKeys, dogHasBalloon, dogSurprise, dogEating, dogWalking, dogFindingBallon;

	private SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {
		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender == null || currentState == DogState.HasKeys)
			spriteRender.sprite = dogHasKeys;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
