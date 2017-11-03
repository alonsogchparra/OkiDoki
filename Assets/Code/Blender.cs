using UnityEngine;
using System.Collections;

public class Blender : MonoBehaviour {

	public GameObject blenderShine;
	public AudioSource blenderSound, cannotSound;

	public Sprite spriteShine, spriteCannot;

	private Juice juice;
	private Player player;

	// Use this for initialization
	void Start () {

		juice = GameObject.Find("Juice").GetComponent<Juice>();
		player = GameObject.Find("Oki").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		blenderShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && juice.lvlNumber < 5 
			&& juice.lvlNumber >= 1 && player.currentState != Player.PlayerState.Sleepy 
			&& player.transform.position.x == -2.85f) {

			blenderSound.Play();
			juice.lvlNumber = 5;
			player.currentPosition = player.transform.position;
			player.actions++;

		} else if(Input.GetMouseButtonDown(0) && player.transform.position.x != -2.85f) {
			blenderShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
			cannotSound.Play();

		} else {
			return;
		}

	}

	void OnMouseExit(){
		blenderShine.GetComponent<SpriteRenderer>().sprite = spriteShine;
		blenderShine.SetActive(false);
	}
		
}
