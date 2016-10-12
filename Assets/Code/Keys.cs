using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {

	public GameObject keysShine;
	public Sprite sprite;
	public bool canTakeIt;

	[HideInInspector]
	public Color alphaFullColor, alphaZeroColor;

	[HideInInspector]
	public SpriteRenderer spriteRender;

	private Dog dog;
	private Player player;
	// Use this for initialization
	void Start () {

		dog = GameObject.Find("Doki").GetComponent<Dog>();
		player = GameObject.Find("Oki").GetComponent<Player>();

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
			keysShine.SetActive(false);

		} else if(dog.transform.position.x != transform.position.x) {

			spriteRender.color = alphaFullColor;
			GetComponent<BoxCollider2D>().enabled = true;

		}

		if(player.transform.position.x == -4.47f && spriteRender.color == alphaFullColor) {
			canTakeIt = true;
		}

		if(player.playerKeys.activeSelf) {
			spriteRender.color = alphaZeroColor;
		}

		if(dog.transform.position.x == transform.position.x && spriteRender.color == alphaZeroColor) {
			dog.currentState = Dog.DogState.Surprise;
		}
	
	}

	void OnMouseOver(){
		
		if(spriteRender.color == alphaFullColor) {
			keysShine.SetActive(true);
		}


		if(Input.GetMouseButtonDown(0) && canTakeIt) {
			
			player.playerKeys.SetActive(true);
			spriteRender.color = alphaZeroColor;
			player.actions++;

		}
	}

	void OnMouseExit(){
		keysShine.SetActive(false);
	}
}
