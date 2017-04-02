using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailKeeper : MonoBehaviour {

	public GameObject mkShine, winnerPanel, musicBg, winnerSound;
	public Sprite spriteShine, spriteCannot, mailKeeperEmpty, mailKeeperFull;

	public GameObject playerMail;

	[HideInInspector]
	public Color alphaFullColor, alphaZeroColor;

	[HideInInspector]
	public SpriteRenderer spriteRender;

	public AudioSource mkSound, cannotSound;

	private Player player;
	private float sec = 1f;
	private Radio radio;
	private Dog dog;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("Oki").GetComponent<Player>();
		dog = GameObject.Find("Doki").GetComponent<Dog>();
		radio = GameObject.Find("Radio").GetComponent<Radio>();

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender == null) {
			spriteRender.sprite = mailKeeperEmpty;
		}

		alphaZeroColor = spriteRender.color;
		alphaZeroColor.a = 0f;
		alphaFullColor = spriteRender.color;
		alphaFullColor.a = 1f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeSprite() {

		if(spriteRender.sprite == mailKeeperEmpty) {
			spriteRender.sprite = mailKeeperFull;
			StartCoroutine(Winner());
		}
		
	}

	void OnMouseOver() {

		if(spriteRender.color == alphaFullColor) {
			mkShine.SetActive(true);
		}

		if (Input.GetMouseButtonDown(0) 
			&& player.transform.position.x != GameObject.Find("Floor 7").transform.position.x) {

			mkShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();

		} else if (Input.GetMouseButtonDown(0) 
			&& player.transform.position.x == GameObject.Find("Floor 7").transform.position.x 
			&& !playerMail.activeSelf) {

			mkShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();

		} else if (Input.GetMouseButtonDown(0) 
			&& player.transform.position.x == GameObject.Find("Floor 7").transform.position.x 
			&& playerMail.activeSelf) {

			mkSound.Play();
			ChangeSprite();
			playerMail.SetActive(false);

		}
		
	}

	void OnMouseExit() {
		
		mkShine.SetActive(false);
		mkShine.GetComponent<SpriteRenderer>().sprite = spriteShine;

	}

	IEnumerator Winner() {

		yield return new WaitForSeconds(sec);

		radio.musicNotes.SetActive(false);
		radio.sleepyMusic.Stop();

		dog.sleepySound.Stop();

		winnerPanel.SetActive(true);
		musicBg.SetActive(false);
		winnerSound.GetComponent<AudioSource>().Play();

	}
}
