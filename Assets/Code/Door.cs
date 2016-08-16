using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Sprite doorClosed, doorOpened;
	public GameObject doorShine; 

	private SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender == null)
			spriteRender.sprite = doorClosed;
	}
	
	// Update is called once per frame
	void Update () {
	
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

		if(Input.GetMouseButtonDown(0)){

			spriteRender.sprite = doorOpened;

		}
		
	}
}
