using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Sprite doorClosed, doorOpened;
	public GameObject doorShine; 
	public bool canOpenIt;

	private SpriteRenderer spriteRender;
	private Player player;

	// Use this for initialization
	void Start () {

		player = GameObject.Find("Oki").GetComponent<Player>();

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender == null)
			spriteRender.sprite = doorClosed;
	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.x == -6.09f) {
			canOpenIt = true;
		} else {
			canOpenIt = false;
		}
	
	}


	void ChangeSprite(){

		if(spriteRender.sprite == doorClosed)
			spriteRender.sprite = doorOpened;
	
	}

	void OnMouseExit(){
		doorShine.SetActive(false);
	}

	void OnMouseOver(){

		if(spriteRender.sprite == doorClosed)
			doorShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && canOpenIt){

			ChangeSprite();

		}

		print(canOpenIt);
		
	}
}
