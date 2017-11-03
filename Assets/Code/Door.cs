using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	public Sprite doorClosed, doorOpened, spriteShine, spriteCannot, doorClosedMail, doorOpenedMail;
	public GameObject doorShine, winnerPanel, winnerSound; 
	public bool canOpenIt;
	public AudioSource cannotSound, openDoorSound;

	public GameObject musicBg;

	[HideInInspector]
	public SpriteRenderer spriteRender;

	private Player player;
	private Dog dog;
	private float sec = 1f;

	// Use this for initialization
	void Start () {

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		player = GameObject.Find("Oki").GetComponent<Player>();

		spriteRender = GetComponent<SpriteRenderer>();

		if(sceneName == "Kitchen") {
				spriteRender.sprite = doorClosed;

		} else if (sceneName == "LivinRoom") { 
				spriteRender.sprite = doorClosedMail;

			dog = GameObject.Find("Doki").GetComponent<Dog>();

		}


	}
	
	// Update is called once per frame
	void Update () {

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		if(sceneName == "Kitchen") {

			if(player.transform.position.x == -6.09f && player.playerKeys.activeSelf) {
				canOpenIt = true;
			} else {
				canOpenIt = false;
			}
			
		} else if(sceneName == "LivinRoom") {

			if(player.transform.position.x == GameObject.Find("Floor 1").transform.position.x 
				&& dog.currentState == Dog.DogState.HasMail) {

				canOpenIt = true;

			} else {
				
				canOpenIt = false;

			}
			
		}


	}


	void ChangeSprite() {

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		switch(sceneName) {

		case "Kitchen":
			
			if(spriteRender.sprite == doorClosed) {

				spriteRender.sprite = doorOpened;
				StartCoroutine(Winner());
			}

			break;

		case "LivinRoom": 

			if(spriteRender.sprite == doorClosedMail) {

				spriteRender.sprite = doorOpenedMail;
				StartCoroutine(player.GameOver());
			}

			break;

		}


			
	
	}

	void OnMouseExit() {

		doorShine.GetComponent<SpriteRenderer>().sprite = spriteShine;
		doorShine.SetActive(false);
	}

	void OnMouseOver() {

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		switch(sceneName) {

		case "Kitchen":

			if(spriteRender.sprite == doorClosed)
				doorShine.SetActive(true);

			if(Input.GetMouseButtonDown(0) && !canOpenIt) {

				doorShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if(Input.GetMouseButtonDown(0) && canOpenIt) {

				openDoorSound.Play();

				ChangeSprite();
				player.actions++;

			}

			break;

		case "LivinRoom":

			if(spriteRender.sprite == doorClosedMail)
				doorShine.SetActive(true);

			if(Input.GetMouseButtonDown(0) && !canOpenIt) {

				doorShine.GetComponent<SpriteRenderer>().sprite = spriteCannot;
				cannotSound.Play();

			} else if(Input.GetMouseButtonDown(0) && canOpenIt) {

				openDoorSound.Play();

				ChangeSprite();
				player.actions++;
				dog.isDoorOpen = true;

			}

			break;
		
		}


	}

	IEnumerator Winner() {

		yield return new WaitForSeconds(sec);

		winnerPanel.SetActive(true);
		musicBg.SetActive(false);
		winnerSound.GetComponent<AudioSource>().Play();

	}
}
