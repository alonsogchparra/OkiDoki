using UnityEngine;
using System.Collections;

public class Fridge : MonoBehaviour {

	public Sprite fridgeOpened, fridgeClosed;
	public GameObject fridgeShine;
	public bool canOpenIt;

	private SpriteRenderer spriteRender;
	private Player player;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();
		player = GameObject.Find("Oki").GetComponent<Player>();
	
		if(spriteRender == null)
			spriteRender.sprite = fridgeClosed;

	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.x == 1.791051f) {
			canOpenIt = true;
		} else {
			canOpenIt = false;
		}
	
	}

	void ChangeSprite(){
		if(spriteRender.sprite == fridgeClosed){
			spriteRender.sprite = fridgeOpened;
		}
	}

	void OnMouseOver(){

		if(spriteRender.sprite == fridgeClosed)
			fridgeShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && canOpenIt ){

			ChangeSprite();
			player.actions++;

		}
	}

	void OnMouseExit(){
		fridgeShine.SetActive(false);
	}
}
