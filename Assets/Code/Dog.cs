using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dog : MonoBehaviour {

	public enum DogState { Happy, HasKeys, HasBalloon, Surprise, Eating,
		Drinking, Walking, Finding, HasMail, WatchTV, HasToy, Sleepy }

	public DogState currentState;

	public Sprite dogHappy, dogHasKeys, dogHasBalloon, dogSurprise, dogEating,
	dogWalking, dogFindingBallon, dogHasMail, dogHasToy, dogWatchesTV, dogSleeping;

	public bool _isFacingRight;
	public float speed = 2.0f;

	public int dogCount = 0;

	public AudioSource yappingSound, eatingSound, surprisedSound, sleepySound;

	public AudioClip eating, surprised, yapping;

	public bool surprisedPlayed = false;
	public bool yappingPlayed = false;

	public bool mailCatched = false;
	public bool isDoorOpen = false;


	[HideInInspector]
	public SpriteRenderer spriteRender;

	private Bowl bowl;
	private Balloon balloon;
	private Keys keys;
	private Televisor tv;
	private Mail mail;
	private Toy toy;
	private Player player;
	private Door door;


	// Use this for initialization
	void Start () {

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		if (sceneName == "Kitchen") {

			currentState = DogState.HasKeys;

			spriteRender = GetComponent<SpriteRenderer>();
			bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
			balloon = GameObject.Find("Balloon Floor Seven").GetComponent<Balloon>();
			keys = GameObject.Find("Keys").GetComponent<Keys>();

			if(spriteRender == null || currentState == DogState.HasKeys)
				spriteRender.sprite = dogHasKeys;
		
		} else if (sceneName == "LivinRoom") {

			currentState = DogState.HasMail;

			spriteRender = GetComponent<SpriteRenderer>();
			tv = GameObject.Find("TV").GetComponent<Televisor>();
			mail = GameObject.Find("Mail").GetComponent<Mail>();
			toy = GameObject.Find("Dog Toy").GetComponent<Toy>();
			player = GameObject.Find("Oki").GetComponent<Player>();
			door = GameObject.Find("Door").GetComponent<Door>();

			if(spriteRender == null || currentState == DogState.HasMail)
				spriteRender.sprite = dogHasMail;

		}



		_isFacingRight = transform.localScale.x > 0;

//		if(spriteRender == null || currentState == DogState.HasKeys)
//			spriteRender.sprite = dogHasKeys;
	
	}
	
	// Update is called once per frame
	void Update () {

		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		switch(sceneName) {

		case "Kitchen":

			if(dogCount == 2 && currentState != DogState.Eating) {

				balloon.currentState = Balloon.BallonState.Normal;
				balloon.balloonFloorFive.GetComponent<Balloon>().currentState = Balloon.BallonState.Normal;
				balloon.balloonFloorTwo.GetComponent<Balloon>().currentState = Balloon.BallonState.Normal;

				BalloonToKeys(keys.transform.position);

			} else if(dogCount == 3) {
				bowl.currentState = Bowl.BowlState.Empty;

			}


			if(bowl.currentState == Bowl.BowlState.Food || bowl.currentState == Bowl.BowlState.Water) {
				DogMoveToBowl();

			} else if (bowl.currentState == Bowl.BowlState.Empty && dogCount == 3) {
				DogMoveToKeys();

			} else if(balloon.currentState == Balloon.BallonState.Wanted 
				&& balloon.balloonFloorSeven.GetComponent<SpriteRenderer>().color == balloon.alphaFullColor) {

				currentState = DogState.Finding;
				DogMoveToBalloon(balloon.balloonFloorSeven.transform.position);


			} else if(balloon.balloonFloorFive.GetComponent<Balloon>().currentState == Balloon.BallonState.Wanted 
				&& balloon.balloonFloorFive.GetComponent<SpriteRenderer>().color == balloon.alphaFullColor) {

				currentState = DogState.Finding;
				DogMoveToBalloon(balloon.balloonFloorFive.transform.position);

			} else if (balloon.balloonFloorTwo.GetComponent<Balloon>().currentState == Balloon.BallonState.Wanted 
				&& balloon.balloonFloorTwo.GetComponent<SpriteRenderer>().color == balloon.alphaFullColor) {

				currentState = DogState.Finding;
				DogMoveToBalloon(balloon.balloonFloorTwo.transform.position);

			}

			break;

			case "LivinRoom":

			if(transform.position.x == mail.transform.position.x) {
				mailCatched = true;
			}

			if(currentState != DogState.Sleepy 
				&& GameObject.Find("Oki").transform.position.x == GameObject.Find("Floor 1").transform.position.x 
				&& !mailCatched) {

				currentState = DogState.Finding;
				DogBackToMail(mail.transform.position);

				toy.currentState = Toy.ToyState.Normal;
				toy.floorSix.GetComponent<Toy>().currentState = Toy.ToyState.Normal;
				toy.couchOne.GetComponent<Toy>().currentState = Toy.ToyState.Normal;
				toy.couchTwo.GetComponent<Toy>().currentState = Toy.ToyState.Normal;
				toy.couchThree.GetComponent<Toy>().currentState = Toy.ToyState.Normal;

			}
				

				if (toy.currentState == Toy.ToyState.Wanted 
				&& toy.floorSix.GetComponent<SpriteRenderer>().color == toy.alphaFullColor) {

				currentState = DogState.Finding;
				GoesToDogToy(toy.floorSix.transform.position);

			} else if (toy.couchOne.GetComponent<Toy>().currentState == Toy.ToyState.Wanted 
				&& toy.couchOne.GetComponent<SpriteRenderer>().color == toy.alphaFullColor) {

				currentState = DogState.Finding;
				GoesToDogToy(toy.couchOne.transform.position);

			} else if (toy.couchTwo.GetComponent<Toy>().currentState == Toy.ToyState.Wanted 
				&& toy.couchTwo.GetComponent<SpriteRenderer>().color == toy.alphaFullColor) {

				currentState = DogState.Finding;
				GoesToDogToy(toy.couchTwo.transform.position);

			} else if (toy.couchThree.GetComponent<Toy>().currentState == Toy.ToyState.Wanted 
				&& toy.couchThree.GetComponent<SpriteRenderer>().color == toy.alphaFullColor) {

				currentState = DogState.Finding;
				GoesToDogToy(toy.couchThree.transform.position);

			} 


			if (tv.spriteRender.sprite == tv.tvOn 
				&& toy.couchOne.GetComponent<Toy>().currentState != Toy.ToyState.Wanted) {
				
				currentState = DogState.Finding;
				DogMoveToTV(tv.transform.position);

			} else if (tv.spriteRender.sprite == tv.tvOn 
				&& toy.couchTwo.GetComponent<Toy>().currentState != Toy.ToyState.Wanted) {

				currentState = DogState.Finding;
				DogMoveToTV(tv.transform.position);

			} else if (tv.spriteRender.sprite == tv.tvOn 
				&& toy.couchThree.GetComponent<Toy>().currentState != Toy.ToyState.Wanted) {

				currentState = DogState.Finding;
				DogMoveToTV(tv.transform.position);

			} else if (tv.spriteRender.sprite == tv.tvOn 
				&& toy.floorSix.GetComponent<Toy>().currentState != Toy.ToyState.Wanted) {

				currentState = DogState.Finding;
				DogMoveToTV(tv.transform.position);

			} 
				

			if(isDoorOpen) {
				
				currentState = DogState.Finding;
				DogGoesOut(door.transform.position);

			}

			break;

		}


	}


	public void Flip() {
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}


	void DogMoveToBowl() {

		if(currentState == DogState.Walking) {
			spriteRender.sprite = dogWalking;	
		}

		var target = bowl.transform.position;
		target.y = transform.position.y;
		target.z = transform.position.z;

		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

		if(transform.position.x == target.x) {
			
			spriteRender.sprite = dogEating;
			currentState = DogState.Eating;

			yappingPlayed = false;

		} else if (transform.position.x != target.x) {
			
			spriteRender.sprite = dogWalking;
			transform.localScale = new Vector3(1f, 1f, 1f);
			currentState = DogState.Walking;

			if(!yappingPlayed) {
				yappingSound.PlayOneShot(yapping);
				yappingPlayed = true;
			}

		}
	}

	void DogMoveToBalloon(Vector3 target) {

		if(currentState == DogState.Finding) {
			spriteRender.sprite = dogFindingBallon;

			if(!yappingPlayed) {
				yappingSound.PlayOneShot(yapping);
				yappingPlayed = true;
			}
		}
			

		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

		if(balloon.gameObject.tag == "BalloonSeven" || balloon.gameObject.tag == "BallooFive"){
			transform.localScale = new Vector3(1f,1f,1f);
		}else if(balloon.tag == "BalloonTwo"){
			transform.localScale = new Vector3(-1f,1f,1f);
		}

		if(transform.position.x == target.x) {
			
			spriteRender.sprite = dogHasBalloon;
			currentState = DogState.HasBalloon;
			yappingPlayed = false;

		} else if(transform.position.x != target.x) {
			
			currentState = DogState.Walking;
			spriteRender.sortingOrder = 50;
		}
	}

	void BalloonToKeys(Vector3 start) {

		yappingSound.Play();

		if(currentState == DogState.HasBalloon) {
			spriteRender.sprite = dogFindingBallon;

			if(!yappingPlayed) {
				yappingSound.PlayOneShot(yapping);
				yappingPlayed = true;
			}

		}

		if(transform.position.x == balloon.balloonFloorTwo.transform.position.x) {
			balloon.balloonFloorTwo.GetComponent<SpriteRenderer>().color = balloon.alphaFullColor;

		} else if(transform.position.x == balloon.balloonFloorFive.transform.position.x) {
			balloon.balloonFloorFive.GetComponent<SpriteRenderer>().color = balloon.alphaFullColor;

		} else if(transform.position.x == balloon.balloonFloorSeven.transform.position.x) {
			balloon.balloonFloorSeven.GetComponent<SpriteRenderer>().color = balloon.alphaFullColor;
		}

		transform.position = Vector3.MoveTowards(transform.position, start, Time.deltaTime * speed);


		if(balloon.gameObject.tag == "BalloonSeven" || balloon.gameObject.tag == "BallooFive"){
			transform.localScale = new Vector3(-1f,1f,1f);
		}else if(balloon.tag == "BalloonTwo"){
			transform.localScale = new Vector3(1f,1f,1f);
		}


		if(transform.position.x == keys.transform.position.x 
			&& keys.spriteRender.color == keys.alphaFullColor) {

			spriteRender.sprite = dogHasKeys;
			currentState = DogState.HasKeys;

			dogCount = 0;

			yappingPlayed = false;

		} else if(transform.position.x == keys.transform.position.x 
			&& keys.spriteRender.color == keys.alphaZeroColor) {

			spriteRender.sprite = dogSurprise;

			if(!surprisedPlayed) {
				surprisedSound.PlayOneShot(surprised);
				surprisedPlayed = true;
			}

		} else if (transform.position.x != keys.transform.position.x) {

			currentState = DogState.Walking;
			spriteRender.sortingOrder = 30;
		}

	}

	void DogMoveToKeys() {

		if(currentState == DogState.Walking) {
			spriteRender.sprite = dogWalking;

			if(!yappingPlayed) {
				yappingSound.PlayOneShot(yapping);
				yappingPlayed = true;
			}
		}

		var target = keys.transform.position;
		target.y = transform.position.y;
		target.z = transform.position.z;

		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

		if(transform.position.x == target.x && keys.spriteRender.color == keys.alphaFullColor) {

			spriteRender.sprite = dogHasKeys;
			currentState = DogState.HasKeys;
			dogCount = 0;

			yappingPlayed = false;

		} else if (transform.position.x == target.x && keys.spriteRender.color == keys.alphaZeroColor) {
			spriteRender.sprite = dogSurprise;
			dogCount = 0;

			if(!surprisedPlayed) {
				surprisedSound.PlayOneShot(surprised);
				surprisedPlayed = true;
			}



		} else if (transform.position.x != target.x) {

			spriteRender.sprite = dogWalking;
			transform.localScale = new Vector3(-1f, 1f, 1f);
			currentState = DogState.Walking;
		}

	}

	void DogMoveToTV(Vector3 target) {

		if(currentState == DogState.Finding) {
			
			spriteRender.sprite = dogFindingBallon;

			if(!yappingPlayed) {
				yappingSound.PlayOneShot(yapping);
				yappingPlayed = true;
			}	

		}
			

		if(transform.position.x == toy.floorSix.transform.position.x) {
			toy.floorSix.GetComponent<SpriteRenderer>().color = toy.alphaFullColor;

		} else if(transform.position.x == toy.couchOne.transform.position.x) {
			toy.couchOne.GetComponent<SpriteRenderer>().color = toy.alphaFullColor;

		} else if(transform.position.x == toy.couchTwo.transform.position.x) {
			toy.couchTwo.GetComponent<SpriteRenderer>().color = toy.alphaFullColor;

		} else if(transform.position.x == toy.couchThree.transform.position.x) {
			toy.couchThree.GetComponent<SpriteRenderer>().color = toy.alphaFullColor;
		}

			
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

		transform.localScale = new Vector3(1f, 1f, 1f);
		spriteRender.sortingOrder = 30;

		if(transform.position.x == target.x) {
			
			spriteRender.sprite = dogWatchesTV;
			currentState = DogState.WatchTV;
			mailCatched = false;

		}

	}


	void DogBackToMail(Vector3 start) {

		yappingSound.Play();

		if(currentState == DogState.Finding) {

			spriteRender.sprite = dogFindingBallon;

			if(!yappingPlayed) {
				yappingSound.PlayOneShot(yapping);
				yappingPlayed = true;
			}

		}

		if(transform.position.x == tv.transform.position.x) {
			tv.spriteRender.sprite = tv.tvOff;
		}


		if(transform.position.x == toy.floorSix.transform.position.x) {
			toy.floorSix.GetComponent<SpriteRenderer>().color = toy.alphaFullColor;

		} else if(transform.position.x == toy.couchOne.transform.position.x) {
			toy.couchOne.GetComponent<SpriteRenderer>().color = toy.alphaFullColor;

		} else if(transform.position.x == toy.couchTwo.transform.position.x) {
			toy.couchTwo.GetComponent<SpriteRenderer>().color = toy.alphaFullColor;

		} else if(transform.position.x == toy.couchThree.transform.position.x) {
			toy.couchThree.GetComponent<SpriteRenderer>().color = toy.alphaFullColor;
		}

		transform.position = Vector3.MoveTowards(transform.position, start, Time.deltaTime * speed);

		transform.localScale = new Vector3(-1f, 1f, 1f);
		spriteRender.sortingOrder = 50;

		if(transform.position.x == mail.transform.position.x
			&& mail.spriteRender.color == mail.alphaFullColor) {

			spriteRender.sprite = dogHasMail;
			currentState = DogState.HasMail;
			dogCount = 0;
			yappingPlayed = false;

		} else if(transform.position.x == mail.transform.position.x
			&& mail.spriteRender.color == mail.alphaZeroColor) {

			spriteRender.sprite = dogSurprise;

			if(!surprisedPlayed) {
				surprisedSound.PlayOneShot(surprised);
				surprisedPlayed = true;
			}
		} 
	}

	void GoesToDogToy(Vector3 target) {
			
		if(currentState == DogState.Finding) {
			
			spriteRender.sprite = dogFindingBallon;

			if(!yappingPlayed) {
				yappingSound.PlayOneShot(yapping);
				yappingPlayed = true;
			}

		}
			
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

		transform.localScale = new Vector3(1f, 1f, 1f);
		spriteRender.sortingOrder = 30;

		if(transform.position.x == target.x) {

			spriteRender.sprite = dogHasToy;
			currentState = DogState.HasToy;
			mailCatched = false;
			yappingPlayed = false;

		}
	}


	public void SendDogToSleep() {

		currentState = DogState.Sleepy;
		spriteRender.sprite = dogSleeping;
		sleepySound.Play();

	}

	public void DogWokeUp() {
		currentState = DogState.HasToy;
		spriteRender.sprite = dogHasToy;
		sleepySound.Stop();
	}

	public void DogGoesOut(Vector3 target) {

		if(currentState == DogState.Finding) {

			spriteRender.sprite = dogFindingBallon;

			if(!yappingPlayed) {
				yappingSound.PlayOneShot(yapping);
				yappingPlayed = true;
			}	

		}

		transform.position = Vector3.MoveTowards(
			transform.position, new Vector3((target.x + 1f), target.y, target.z), Time.deltaTime * speed);

		transform.localScale = new Vector3(-1f, 1f, 1f);
		spriteRender.sortingOrder = 30;


	}


	void OnTriggerEnter2D(Collider2D other) {

		Scene currentScene = SceneManager.GetActiveScene();
	 	string sceneName = currentScene.name;

		if (sceneName == "Kitchen") {

			var tgt_bowl = bowl.transform.position;
			var tgt_keys = keys.transform.position;

			if(other.tag == "Bowl") {

				AudioSource.PlayClipAtPoint(eating, tgt_bowl);

			} else if(other.tag == "Keys") {

				if(currentState == DogState.Surprise) {
					AudioSource.PlayClipAtPoint(surprised, tgt_keys);
				}
			}

		}


	}

}
