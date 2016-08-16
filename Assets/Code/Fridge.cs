using UnityEngine;
using System.Collections;

public class Fridge : MonoBehaviour {

	public Sprite fridgeOpened, fridgeClosed;
	public GameObject fridgeShine;

	private SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();
	
		if(spriteRender == null)
			spriteRender.sprite = fridgeClosed;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ChangeSprite(){
		if(spriteRender.sprite == fridgeClosed){
			spriteRender.sprite = fridgeOpened;
		}
	}

	void OnMouseOver(){
		fridgeShine.SetActive(true);
	}

	void OnMouseExit(){
		fridgeShine.SetActive(false);
	}
}
