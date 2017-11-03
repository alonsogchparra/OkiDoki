using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fridge : MonoBehaviour {

	public Sprite fridgeOpened, fridgeClosed, spriteBowlWater, spriteBowlEmpty, spriteBowlFood,
	spriteShine,spriteCannot;

	public GameObject fridgeShine, frigdePanel, servingWater, waterShine;
	public bool canOpenIt, canServeWater;
	public AudioSource fridgeSound, cannotSound; //Fridge
	public AudioSource waterSound; //Water


	public Image imgBowl;

	public Sprite spriteWaterShine, spriteWaterCannot;

	private SpriteRenderer spriteRender;
	private Player player;
	private float sec = .4f;
	private float secs = 1f;
	private Bowl bowl;
	private Color alphaHalfColor, alphaFullColor;
	private Juice juice;

	// Use this for initialization
	void Start () {

		canServeWater = false;

		spriteRender = GetComponent<SpriteRenderer>();
		player = GameObject.Find("Oki").GetComponent<Player>();
		bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
		juice = GameObject.Find("Juice").GetComponent<Juice>();
	
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

		if(bowl.playerBowl.activeSelf 
			&& bowl.playerBowl.GetComponent<SpriteRenderer>().sprite == player.bowlFood) {

			canServeWater = false;

		} else if(bowl.playerBowl.activeSelf 
			&& bowl.playerBowl.GetComponent<SpriteRenderer>().sprite != player.bowlFood) {

			canServeWater = true;

		}

		if(bowl.currentState == Bowl.BowlState.SignFood) {

			imgBowl.sprite = spriteBowlFood;
			
		} else if (bowl.currentState == Bowl.BowlState.SignWater) {

			imgBowl.sprite = spriteBowlWater;

		} else {

			imgBowl.sprite = spriteBowlEmpty;

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

			fridgeSound.Play();

			ChangeSprite();
			player.actions++;
			juice.lvlNumber--;

			if(juice.lvlNumber == 0) {
				player.StartCoroutine(player.GameOver());
			} else {
				StartCoroutine(FridgePanelOpened());
			}



		} else if (Input.GetMouseButtonDown(0) && !canOpenIt) {
			
			fridgeShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();

		}
	}

	void OnMouseExit() {
		
		fridgeShine.SetActive(false);
		fridgeShine.GetComponent<SpriteRenderer>().sprite = spriteShine;
		waterShine.GetComponent<Image>().sprite = spriteWaterShine;

	}

	IEnumerator FridgePanelOpened() {

		yield return new WaitForSeconds(sec);

		frigdePanel.SetActive(true);
//		canServeWater = true;

	}



	public void FillBowlWater() {

		if(bowl.playerBowl.activeSelf && canServeWater 
			&& bowl.playerBowl.GetComponent<SpriteRenderer>().sprite == player.bowlEmpty) {

			waterSound.Play();

			servingWater.SetActive(true);
			imgBowl.sprite = spriteBowlWater;
			bowl.currentState = Bowl.BowlState.SignWater;

			player.bowlSpriteRender.sprite = player.bowlWater;
			StartCoroutine(BowlWaterFull());

		} else {

			cannotSound.Play();
			waterShine.GetComponent<Image>().sprite = spriteWaterCannot;

		}
	}
		

	IEnumerator BowlWaterFull() {

		yield return new WaitForSeconds(secs);

		canServeWater = false;
		servingWater.SetActive(false);

	}
}
