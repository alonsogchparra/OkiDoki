using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum PlayerState { Happy, Normal, Dizzy, Sleepy }

	public PlayerState currentState = PlayerState.Happy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
