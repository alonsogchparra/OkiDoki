using UnityEngine;
using System.Collections;

public class Bowl : MonoBehaviour {

	public enum BowlState {Empty, Food, Water, SignWater, SignFood }

	public BowlState currentState = BowlState.Empty;
	public GameObject bowlShine;
	public Sprite bowlEmpty, bowlWater, bowlFood;

	private SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender == null || currentState == BowlState.Empty)
			spriteRender.sprite = bowlEmpty;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		bowlShine.SetActive(true);
	}

	void OnMouseExit(){
		bowlShine.SetActive(false);
	}
}
