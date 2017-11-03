using UnityEngine;
using System.Collections;

public class DogFood : MonoBehaviour {

	public GameObject dogFoodShine, bowlPlayer;
	public bool canFeedDog;
	public AudioSource dogFoodSound, cannotSound;

	public Sprite spriteShine, spriteCannot;


	private Player player;
	private Bowl bowl;
	private Juice juice;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find("Oki").GetComponent<Player>();
		bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
		juice = GameObject.Find("Juice").GetComponent<Juice>();

	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.x == 0.36f && bowl.playerBowl.activeSelf) {
			canFeedDog = true;
		} else {
			canFeedDog = false;
		}
	
	}

	void OnMouseOver(){
		dogFoodShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && canFeedDog 
			&& bowl.playerBowl.GetComponent<SpriteRenderer>().sprite == player.bowlFood) {
			
			dogFoodShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();

		} else if(Input.GetMouseButtonDown(0) && canFeedDog 
			&& bowl.playerBowl.GetComponent<SpriteRenderer>().sprite == player.bowlWater) {

			dogFoodShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();

		} else if(Input.GetMouseButtonDown(0) && canFeedDog 
			&& bowl.playerBowl.GetComponent<SpriteRenderer>().sprite == player.bowlEmpty) {

			player.ChangeBowlSprite();

			dogFoodSound.Play();
			player.actions++;
			juice.lvlNumber--;

		} else if(Input.GetMouseButtonDown(0) && !canFeedDog) {
			
			dogFoodShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();

		}

	}

	void OnMouseExit(){
		
		dogFoodShine.GetComponent<SpriteRenderer>().sprite = spriteShine;
		dogFoodShine.SetActive(false);

	}
}
