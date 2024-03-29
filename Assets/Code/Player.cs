﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public GameObject playerBalloon, playerKeys, playerMail, playerToy, gameOverPanel;
	public int actions = 0;
	public Text gameOverActions, winnerActions;
	public bool isMoving;
	public AudioClip looseSound;

	public GameObject musicBg, looserSound;

	[HideInInspector]
	public int direction = 0;
	[HideInInspector]
	public int currentActions;

	private SpriteRenderer spriteRender;
	private DogFood dogFood;
	private Bowl bowl;
	private Dog dog;
	private Floor floor;
	private Text txtActions;
	private float sec = 1f;

	// Use this for initialization
	void Start () {

		Scene currentScene = SceneManager.GetActiveScene();

		string sceneName = currentScene.name;

		if (sceneName == "Kitchen") {

			spriteRender = GetComponent<SpriteRenderer>();
			dogFood = GameObject.Find("Dog Food").GetComponent<DogFood>();
			bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
			dog = GameObject.Find("Doki").GetComponent<Dog>();
			txtActions = GameObject.Find("Text Actions").GetComponent<Text>();

			
		} else if (sceneName == "LivinRoom") {

			spriteRender = GetComponent<SpriteRenderer>();
			dog = GameObject.Find("Doki").GetComponent<Dog>();
			txtActions = GameObject.Find("Text Actions").GetComponent<Text>();
			
		}



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

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

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
//			StartCoroutine(GameOver());
			break;

		default:
			print("Nothing to do Here!!!");
			break;

		}

		if(currentPosition != transform.position && canMove) {

			MoveTowards(currentPosition);
			isMoving = true;

		} else if(currentPosition == transform.position && canMove) {
			isMoving = false;

		} else if (!canMove) {
			return;
		}

		if(juice.lvlNumber < 0)
			juice.lvlNumber = 0;


		if(dog.currentState == Dog.DogState.Walking && Input.GetMouseButtonDown(0)) {
			
		} else if (dog.currentState != Dog.DogState.Walking) {
//			Cursor.lockState = CursorLockMode.Confined;
		}

		if(direction == 1) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		} else if(direction == -1) {
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}

		txtActions.text = (actions.ToString());
		gameOverActions.text = (actions.ToString());
		winnerActions.text = (actions.ToString());

		if(sceneName == "Kitchen") {
			
			if(bowl.currentState == Bowl.BowlState.Empty) {
				bowlSpriteRender.sprite = bowlEmpty;
			}

		}
			
		currentActions = actions;

	}

	public void Flip() {
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
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

	public IEnumerator GameOver() {

		yield return new WaitForSeconds(sec);

		musicBg.SetActive(false);
		gameOverPanel.SetActive(true);
		looserSound.GetComponent<AudioSource>().Play();

	}
		
}
