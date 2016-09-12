﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fridge : MonoBehaviour {

	public Sprite fridgeOpened, fridgeClosed, spriteBowlWater, spriteBowlEmpty;
	public GameObject fridgeShine, frigdePanel, servingWater;
	public bool canOpenIt, canServeWater;


	public Image imgBowl;

	private SpriteRenderer spriteRender;
	private Player player;
	private float sec = .4f;
	private float secs = 1f;
	private Bowl bowl;
	private Color alphaHalfColor, alphaFullColor;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();
		player = GameObject.Find("Oki").GetComponent<Player>();
		bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
	
		if(spriteRender == null)
			spriteRender.sprite = fridgeClosed;

		alphaHalfColor = imgBowl.color;
		alphaHalfColor.a = 0.5f;
		alphaFullColor = imgBowl.color;
		alphaFullColor.a = 1f;

	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.x == 1.791051f) {
			canOpenIt = true;
		} else {
			canOpenIt = false;
		}

		if(bowl.playerBowl.activeSelf) {

			imgBowl.color = alphaFullColor;
			
		} else {

			imgBowl.color = alphaHalfColor;
		}
	
	}

public void ChangeSprite(){
		if(spriteRender.sprite == fridgeClosed){
			spriteRender.sprite = fridgeOpened;
		} else {
			spriteRender.sprite = fridgeClosed;
		}
	}

	void OnMouseOver(){

		if(spriteRender.sprite == fridgeClosed)
			fridgeShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && canOpenIt ){

			ChangeSprite();
			player.actions++;
			StartCoroutine(FridgePanelOpened());

		}
	}

	void OnMouseExit(){
		fridgeShine.SetActive(false);
	}

	IEnumerator FridgePanelOpened() {

		yield return new WaitForSeconds(sec);

		frigdePanel.SetActive(true);
		canServeWater = true;

	}



	public void FillBowlWater() {
		if(Input.GetMouseButtonDown(0) && bowl.playerBowl.activeSelf && canServeWater) {
			
			servingWater.SetActive(true);
			imgBowl.sprite = spriteBowlWater;
			bowl.currentState = Bowl.BowlState.SignWater;

			player.bowlSpriteRender.sprite = player.bowlWater;
			StartCoroutine(BowlWaterFull());

		}
	}

	IEnumerator BowlWaterFull() {

		yield return new WaitForSeconds(secs);

		canServeWater = false;
		servingWater.SetActive(false);

	}
}
