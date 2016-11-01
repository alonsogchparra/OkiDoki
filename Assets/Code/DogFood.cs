using UnityEngine;
using System.Collections;

public class DogFood : MonoBehaviour {

	public GameObject dogFoodShine, bowlPlayer;
	public bool canFeedDog;
	public AudioSource dogFoodSound, cannotSound;

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

		if(Input.GetMouseButtonDown(0) && canFeedDog){
			player.ChangeBowlSprite();

			dogFoodSound.Play();
			player.actions++;
			juice.lvlNumber--;

		} else if(Input.GetMouseButtonDown(0) && !canFeedDog) {
			cannotSound.Play();
		}

	}

	void OnMouseExit(){
		dogFoodShine.SetActive(false);
	}
}
