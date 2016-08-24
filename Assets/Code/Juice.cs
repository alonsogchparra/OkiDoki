using UnityEngine;
using System.Collections;

public class Juice : MonoBehaviour {

	public GameObject lvlOne, lvlTwo, lvlThree, lvlFour, lvlFive;
	public int lvlNumber = 5;

//	private Player player;

	// Use this for initialization
	void Start () {
	
//		player = GameObject.Find("Oki").GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {

		switch (lvlNumber) {

		case 0: 
			lvlOne.SetActive(false);
			lvlTwo.SetActive(false);
			lvlThree.SetActive(false);
			lvlFour.SetActive(false);
			lvlFive.SetActive(false);
			break;

		case 1: 
			lvlOne.SetActive(true);
			lvlTwo.SetActive(false);
			lvlThree.SetActive(false);
			lvlFour.SetActive(false);
			lvlFive.SetActive(false);
			break;

		case 2: 
			lvlOne.SetActive(true);
			lvlTwo.SetActive(true);
			lvlThree.SetActive(false);
			lvlFour.SetActive(false);
			lvlFive.SetActive(false);
			break;

		case 3: 
			lvlOne.SetActive(true);
			lvlTwo.SetActive(true);
			lvlThree.SetActive(true);
			lvlFour.SetActive(false);
			lvlFive.SetActive(false);
			break;

		case 4: 
			lvlOne.SetActive(true);
			lvlTwo.SetActive(true);
			lvlThree.SetActive(true);
			lvlFour.SetActive(true);
			lvlFive.SetActive(false);
			break;

		case 5: 
			lvlOne.SetActive(true);
			lvlTwo.SetActive(true);
			lvlThree.SetActive(true);
			lvlFour.SetActive(true);
			lvlFive.SetActive(true);
			break;

			default:
//			print("Nothing to do HERE!");
			lvlNumber = 0;
			break;

		}
	
	}
}
