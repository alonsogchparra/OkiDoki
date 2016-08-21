using UnityEngine;
using System.Collections;

public class Bowl : MonoBehaviour {

	public enum BowlState {Empty, Food, Water, SignWater, SignFood, SignEmpty }

	public BowlState currentState = BowlState.Empty;
	public GameObject bowlShine;
	public Sprite bowlEmpty, bowlWater, bowlFood;
	public bool canTakeIt;
	public GameObject playerBowl;

	private SpriteRenderer spriteRender;
	private Player player;
	private Color alphaHalfColor, alphaFullColor;


	// Use this for initialization
	void Start () {

		player = GameObject.Find("Oki").GetComponent<Player>();

//		playerBowl = GameObject.Find("Oki Bowl");

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender == null || currentState == BowlState.Empty)
			spriteRender.sprite = bowlEmpty;

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

		switch (currentState) {

//			case BowlState.Empty:
//				spriteRender.sprite = bowlEmpty;
//				break;

			case BowlState.SignEmpty:
				bowlShine.SetActive(true);
				break;

			default:
				break;
		}
	
	}

	void OnMouseOver(){
		bowlShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && canTakeIt && currentState == BowlState.Empty) {
			spriteRender.color = alphaHalfColor;
			currentState = BowlState.SignEmpty;
			playerBowl.SetActive(true);

		} else if(Input.GetMouseButtonDown(0) 
			&& canTakeIt && playerBowl.activeSelf && currentState == BowlState.SignEmpty) {

			spriteRender.color = alphaFullColor;
			currentState = BowlState.Empty;
			playerBowl.SetActive(false);
		}

	}

	void OnMouseExit(){
		bowlShine.SetActive(false);
	}
}
