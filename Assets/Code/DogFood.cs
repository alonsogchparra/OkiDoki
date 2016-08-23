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

		if(Input.GetMouseButtonDown(0) && canFeedDog){
			player.ChangeBowlSprite();
		}

	}

	void OnMouseExit(){
		dogFoodShine.SetActive(false);
	}
}
