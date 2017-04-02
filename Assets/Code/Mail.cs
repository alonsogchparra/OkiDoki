using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour {

	public GameObject mailShine;
	public Sprite spriteShine, spriteCannot, sprite;
	public bool canTakeIt;

	public GameObject playerMail;

	[HideInInspector]
	public Color alphaFullColor, alphaZeroColor;

	[HideInInspector]
	public SpriteRenderer spriteRender;

	public AudioSource mailSound, cannotSound;

	private Dog dog;
	private Player player;
	private Juice juice;
	private MailKeeper mk;

	// Use this for initialization
	void Start () {

		dog = GameObject.Find("Doki").GetComponent<Dog>();
		player = GameObject.Find("Oki").GetComponent<Player>();
		juice = GameObject.Find("Juice").GetComponent<Juice>();
		mk = GameObject.Find("Mail Keeper").GetComponent<MailKeeper>();

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender == null) {
			spriteRender.sprite = sprite;
		}

		alphaZeroColor = spriteRender.color;
		alphaZeroColor.a = 0f;
		alphaFullColor = spriteRender.color;
		alphaFullColor.a = 1f;

		
	}
	
	// Update is called once per frame
	void Update () {

		if (dog.transform.position.x == transform.position.x) {
			
			spriteRender.color = alphaZeroColor;
			GetComponent<BoxCollider2D>().enabled = false;
			mailShine.SetActive(false);

		} else if (dog.transform.position.x != transform.position.x) {

			spriteRender.color = alphaFullColor;
			GetComponent<BoxCollider2D>().enabled = true;

		}

		if (player.transform.position.x == GameObject.Find("Floor 1").transform.position.x 
			&& spriteRender.color == alphaFullColor && dog.currentState == Dog.DogState.Sleepy) {

			canTakeIt = true;

		}
			
		if (player.playerMail.activeSelf) {
			spriteRender.color = alphaZeroColor;
		}

		if (!player.playerMail.activeSelf && mk.spriteRender.sprite == mk.mailKeeperFull) {
			spriteRender.color = alphaZeroColor;
		}

		if(dog.transform.position.x == transform.position.x
			&& spriteRender.color == alphaZeroColor && player.playerMail.activeSelf) {

			dog.currentState = Dog.DogState.Surprise;
		}
	}

	void OnMouseOver() {

		if(spriteRender.color == alphaFullColor) {
			mailShine.SetActive(true);
		}

		if(Input.GetMouseButtonDown(0) && !canTakeIt) {

			mailShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();

		} else if (Input.GetMouseButtonDown(0) && canTakeIt && spriteRender.color == alphaFullColor) {

			mailSound.Play();

			player.playerMail.SetActive(true);
			spriteRender.color = alphaZeroColor;
			GetComponent<BoxCollider2D>().enabled = false;
			player.actions++;
			juice.lvlNumber--;
		}
	}

	void OnMouseExit() {

		mailShine.SetActive(false);
		mailShine.GetComponent<SpriteRenderer>().sprite = spriteShine;

	}
}
