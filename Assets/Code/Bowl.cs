﻿using UnityEngine;
using System.Collections;

public class Bowl : MonoBehaviour {

	public enum BowlState { Empty, Food, Water, SignWater, SignFood, SignEmpty }

	public BowlState currentState = BowlState.Empty;
	public GameObject bowlShine;
	public Sprite bowlEmpty, bowlWater, bowlFood, spriteShine, spriteCannot;
	public bool canTakeIt;
	public GameObject playerBowl;
	public AudioSource cannotSound;

	[HideInInspector]
	public SpriteRenderer spriteRender;

	[HideInInspector]
	public Color alphaHalfColor, alphaFullColor;

	private Player player;
	private Juice juice;
	private Fridge fridge;


	// Use this for initialization
	void Start () {

		player = GameObject.Find("Oki").GetComponent<Player>();
		juice = GameObject.Find("Juice").GetComponent<Juice>();
		fridge = GameObject.Find("Frigde").GetComponent<Fridge>();

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

		if( player.transform.position.x == 7.14f && !player.playerBalloon.activeSelf ) {
			canTakeIt = true;
		} else {
			canTakeIt = false;
		}

		switch (currentState) {

			case BowlState.Empty:
				spriteRender.sprite = bowlEmpty;
				break;

			case BowlState.SignEmpty:
				bowlShine.SetActive(true);
				break;

			case BowlState.SignFood:
				bowlShine.SetActive(true);
				spriteRender.sprite = bowlFood;
				spriteRender.color = alphaHalfColor;
				break;

			case BowlState.SignWater:
				bowlShine.SetActive(true);
				spriteRender.sprite = bowlWater;
				spriteRender.color = alphaHalfColor;
				break;

			default:
				break;
		}
	
	}

	void OnMouseOver(){
		bowlShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && !canTakeIt) {
			
			bowlShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();
			
		} else if(Input.GetMouseButtonDown(0) && player.playerKeys.activeSelf) {
			
			bowlShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();
			
		} else if(Input.GetMouseButtonDown(0) && canTakeIt && currentState == BowlState.Empty) {
			
			spriteRender.color = alphaHalfColor;
			currentState = BowlState.SignEmpty;
			playerBowl.SetActive(true);

			player.actions++;
			juice.lvlNumber--;

			if (juice.lvlNumber < 1)
				StartCoroutine(player.GameOver());

		} else if(Input.GetMouseButtonDown(0) 
			&& canTakeIt && playerBowl.activeSelf && currentState == BowlState.SignEmpty) {

			spriteRender.color = alphaFullColor;
			currentState = BowlState.Empty;
			playerBowl.SetActive(false);

			player.actions++;
			juice.lvlNumber--;

			if (juice.lvlNumber < 1)
				StartCoroutine(player.GameOver());

		} else if (Input.GetMouseButtonDown(0) && currentState == BowlState.SignFood) {

			spriteRender.color = alphaFullColor;
			currentState = BowlState.Food;
			playerBowl.SetActive(false);

			player.actions++;
			juice.lvlNumber--;

			if (juice.lvlNumber < 1)
				StartCoroutine(player.GameOver());


		} else if(Input.GetMouseButtonDown(0) && currentState == BowlState.SignWater){

			spriteRender.color = alphaFullColor;
			currentState = BowlState.Water;
			playerBowl.SetActive(false);

			player.actions++;
			juice.lvlNumber--;

			fridge.imgBowl.sprite = fridge.spriteBowlEmpty;

			if (juice.lvlNumber < 1)
				StartCoroutine(player.GameOver());

		}

	}

	void OnMouseExit(){
		
		bowlShine.SetActive(false);
		bowlShine.GetComponent<SpriteRenderer>().sprite = spriteShine;

	}
}
