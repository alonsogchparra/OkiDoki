using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Televisor : MonoBehaviour {

	public GameObject tvShine;
	public AudioSource tvSound, cannotSound;
	public Sprite spriteShine, spriteCannot, tvOn, tvOff;
	public bool canTurnOnTV;

	[HideInInspector]
	public SpriteRenderer spriteRender;

	private Juice juice;
	private Player player;
	private Dog dog;

	// Use this for initialization
	void Start () {

		juice = GameObject.Find("Juice").GetComponent<Juice>();
		player = GameObject.Find("Oki").GetComponent<Player>();
		dog = GameObject.Find("Doki").GetComponent<Dog>();

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender == null) {
			spriteRender.sprite = tvOff;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if(GameObject.Find("Dog Toy").GetComponent<Toy>().currentState != Toy.ToyState.Normal 
			|| GameObject.Find("Couch 1").GetComponent<Toy>().currentState != Toy.ToyState.Normal 
			|| GameObject.Find("Couch 2").GetComponent<Toy>().currentState != Toy.ToyState.Normal 
			|| GameObject.Find("Couch 3").GetComponent<Toy>().currentState != Toy.ToyState.Normal ){

			canTurnOnTV = false;

		} else if (player.transform.position.x == GameObject.Find("Floor 2").transform.position.x) {
			
			canTurnOnTV = true;

		} else {
			
			canTurnOnTV = false;
		}

		if(dog.currentState == Dog.DogState.WatchTV 
			&& player.transform.position.x == GameObject.Find("Floor 2").transform.position.x) {

			canTurnOnTV = false;

		}
		
	}

	void ChangeSprite() {

		if(spriteRender.sprite == tvOff) {

			spriteRender.sprite = tvOn;
			dog.mailCatched = false;

		} 
//		else if (spriteRender.sprite == tvOn) {
//			
//			spriteRender.sprite = tvOff;
//			dog.mailCatched = false;
//
//		}
	}

	void OnMouseOver() {
		
		tvShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && canTurnOnTV) {

			juice.lvlNumber--;
			player.actions++;

			if (juice.lvlNumber < 1)
				StartCoroutine(player.GameOver());

			ChangeSprite();
			tvSound.Play();
			
		} else if (Input.GetMouseButtonDown(0) && !canTurnOnTV) {
			cannotSound.Play();
			tvShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
		}
	}

	void OnMouseExit() {
		tvShine.SetActive(false);
		tvShine.GetComponent<SpriteRenderer>().sprite = spriteShine;
	}
}
