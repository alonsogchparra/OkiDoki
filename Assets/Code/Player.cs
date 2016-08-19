﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum PlayerState { Happy, Normal, Dizzy, Sleepy }

	public PlayerState currentState = PlayerState.Happy;
	public Sprite okiHappy, okiNormal, okiDizzy, okiSleepy;
	public bool _isFacingRight;
	public float speed = 2.0f;
	public bool canMove;

	public Juice juice;

	private SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender.sprite == null || currentState == PlayerState.Happy) {
			spriteRender.sprite = okiHappy;
		}
	
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

	
	}

	public void Flip() {
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}
