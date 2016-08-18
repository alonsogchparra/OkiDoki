using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum PlayerState { Happy, Normal, Dizzy, Sleepy }

	public PlayerState currentState = PlayerState.Happy;
	public Sprite okiHappy, okiNormal, okiDizzy, okiSleepy;

	private SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();

		if(spriteRender.sprite == null || currentState == PlayerState.Happy) {
			spriteRender.sprite = okiHappy;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
