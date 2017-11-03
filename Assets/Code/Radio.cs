using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

	public GameObject musicNotes, radioShine, musicBackground;
	public Sprite spriteShine, spriteCannot, sprite;
	public AudioSource cannotSound, couchOneMusic, couchTwoMusic, sleepyMusic, bgMusic;

	[HideInInspector]
	public Color alphaFullColor, alphaZeroColor;

	[HideInInspector]
	public SpriteRenderer spriteRender;

	private Dog dog;
	private Player player;
	private Juice juice;
	private Toy toy;

	// Use this for initialization
	void Start () {

		dog = GameObject.Find("Doki").GetComponent<Dog>();
		player = GameObject.Find("Oki").GetComponent<Player>();
		juice = GameObject.Find("Juice").GetComponent<Juice>();
		toy = GameObject.Find("Dog Toy").GetComponent<Toy>();

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender == null)
			spriteRender.sprite = sprite;

		alphaZeroColor = spriteRender.color;
		alphaZeroColor.a = 0f;
		alphaFullColor = spriteRender.color;
		alphaFullColor.a = 1f;
		
	}

	// Update is called once per frame
	void Update () {

//		if(dog.currentState == Dog.DogState.HasMail &&) {
//			musicNotes.SetActive(false);
//		}

		if(dog.transform.position.x == toy.couchOne.transform.position.x 
			&& dog.spriteRender.sprite == dog.dogSurprise  && !musicNotes.activeSelf) {

			dog.spriteRender.sprite = dog.dogHasToy;

		} else if(dog.transform.position.x == toy.couchTwo.transform.position.x 
			&& dog.spriteRender.sprite == dog.dogSurprise  && !musicNotes.activeSelf) {

			dog.spriteRender.sprite = dog.dogHasToy;

		} else if(dog.transform.position.x == toy.couchThree.transform.position.x 
			&& dog.spriteRender.sprite == dog.dogSurprise  && !musicNotes.activeSelf) {

			dog.spriteRender.sprite = dog.dogHasToy;

		}
		
	}

	void OnMouseOver() {

		if(spriteRender.color == alphaFullColor) {
			radioShine.SetActive(true);
		}

		if(Input.GetMouseButtonDown(0) 
			&& player.transform.position.x != GameObject.Find("Floor 5").transform.position.x ) {

			radioShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();

			
		} else if (Input.GetMouseButtonDown(0) 
			&& player.transform.position.x == GameObject.Find("Floor 5").transform.position.x 
			&& !musicNotes.activeSelf) {

			if(dog.transform.position.x == toy.couchThree.transform.position.x) {
				
				dog.SendDogToSleep();
				sleepyMusic.Play();
				musicBackground.SetActive(false);

			} else if(dog.transform.position.x == toy.couchTwo.transform.position.x) {
				
				dog.spriteRender.sprite = dog.dogSurprise;
				couchTwoMusic.Play();
				musicBackground.SetActive(false);

			} else if(dog.transform.position.x == toy.couchOne.transform.position.x) {
				
				dog.spriteRender.sprite = dog.dogSurprise;
				couchOneMusic.Play();
				musicBackground.SetActive(false);

			} else if(dog.currentState == Dog.DogState.HasMail 
				|| dog.transform.position.x == toy.floorSix.transform.position.x) {

				bgMusic.Play();
				musicBackground.SetActive(false);
			}


			musicNotes.SetActive(true);
			player.actions++;
			juice.lvlNumber--;

			if (juice.lvlNumber < 1)
				StartCoroutine(player.GameOver());


		} else if (Input.GetMouseButtonDown(0) 
			&& player.transform.position.x == GameObject.Find("Floor 5").transform.position.x 
			&& dog.currentState == Dog.DogState.Sleepy
			&& musicNotes.activeSelf) {

			sleepyMusic.Stop();
			dog.DogWokeUp();

			musicBackground.SetActive(true);
			musicNotes.SetActive(false);

			player.actions++;
			juice.lvlNumber--;

			if (juice.lvlNumber < 1)
				StartCoroutine(player.GameOver());

			
		} else if (Input.GetMouseButtonDown(0) 
			&& player.transform.position.x == GameObject.Find("Floor 5").transform.position.x 
			&& musicNotes.activeSelf) {

			sleepyMusic.Stop();
			couchOneMusic.Stop();
			couchTwoMusic.Stop();
			bgMusic.Stop();

			musicBackground.SetActive(true);

			musicNotes.SetActive(false);
			player.actions++;
			juice.lvlNumber--;

			if (juice.lvlNumber < 1)
				StartCoroutine(player.GameOver());

		}
		
	}

	void OnMouseExit() {

		radioShine.SetActive(false);
		radioShine.GetComponent<SpriteRenderer>().sprite = spriteShine;
		
	}
}
