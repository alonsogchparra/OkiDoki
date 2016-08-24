using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	public enum BallonState { Normal, Picked, Wanted }

	public BallonState currentState = BallonState.Normal;
	public GameObject balloonShine, playerBalloon;
	public bool canTakeIt;
	public Sprite balloon;

	private Player player;
	private SpriteRenderer spriteRender;
	private Color alphaHalfColor, alphaFullColor;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find("Oki").GetComponent<Player>();

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender == null)
			spriteRender.sprite = balloon;

		alphaHalfColor = spriteRender.color;
		alphaHalfColor.a = 0.5f;
		alphaFullColor = spriteRender.color;
		alphaFullColor.a = 1f;

	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.x == 7.14f) {
			canTakeIt = true;
		} else {
			canTakeIt = false;
		}

		switch(currentState) {

			case BallonState.Picked:
				balloonShine.SetActive(true);
				canTakeIt = false;
				break;

			case BallonState.Wanted:
				balloonShine.SetActive(true);
				canTakeIt = false;
				break;

			default:
				break;

		}
	
	}

	void OnMouseOver(){
		balloonShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && canTakeIt) {
			
			playerBalloon.SetActive(true);
			spriteRender.color = alphaHalfColor;
			currentState = BallonState.Picked;

		}else if(Input.GetMouseButtonDown(0) && currentState == BallonState.Picked) {
			
			playerBalloon.SetActive(false);
			spriteRender.color = alphaFullColor;
			currentState = BallonState.Wanted;

		}

	}

	void OnMouseExit(){
		balloonShine.SetActive(false);
	}
}
