using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceJar : MonoBehaviour {

	public GameObject juiceJarShine;

	//Here the AudioSource
	public AudioSource juiceJarSound, cannotSound;

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

	void OnMouseOver() {
		juiceJarShine.SetActive(true);

		if(Input.GetMouseButtonDown(0) && juice.lvlNumber < 5 
			&& juice.lvlNumber >= 1 && player.currentState != Player.PlayerState.Sleepy 
			&& player.transform.position.x == GameObject.Find("Floor 7").transform.position.x) {

			juiceJarSound.Play();
			juice.lvlNumber = 5;
			player.currentPosition = player.transform.position;
			player.actions++;

		} else if (Input.GetMouseButtonDown(0) 
			&& player.transform.position.x != GameObject.Find("Floor 7").transform.position.x) {
			juiceJarShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;

			cannotSound.Play();

		} else {
			return;
		}
	}

	void OnMouseExit() {
		juiceJarShine.GetComponent<SpriteRenderer>().sprite = spriteShine;
		juiceJarShine.SetActive(false);
	}

}
