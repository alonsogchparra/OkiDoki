using UnityEngine;
using System.Collections;

public class DogFood : MonoBehaviour {

	public GameObject dogFoodShine, bowlPlayer;
	public bool canFeedDog;

	private Player player;

	// Use this for initialization
	void Start () {
	
		player = GameObject.Find("Oki").GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.x == 0.36f) {
			canFeedDog = true;
		} else {
			canFeedDog = false;
		}
	
	}

	void OnMouseOver(){
		dogFoodShine.SetActive(true);

		//TODO: ARREGLAR EL SPRITE BOWL DEL PLAYER PARA QUE CAMBIE

//		if(Input.GetMouseButtonDown(0) && canFeedDog 
//			&& bowlPlayer.activeSelf && player.bowlSpriteRender.sprite == player.bowlEmpty) {
//
//			player.bowlSpriteRender.sprite = player.bowlFood;
//		}

		if(Input.GetMouseButtonDown(0) && canFeedDog){
			player.bowlSpriteRender.sprite = player.bowlFood;
		}

//		print(canFeedDog);

	}

	void OnMouseExit(){
		dogFoodShine.SetActive(false);
	}
}
