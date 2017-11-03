using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

	public static GlobalControl Instance;

	public float language;


	void Awake () {

		if(Instance == null) {

			DontDestroyOnLoad(gameObject);
			Instance = this;

		} else if (Instance != null) {
			
			Destroy(gameObject);
		}

	}

	// Use this for initialization
	void Start () {

		language = GlobalControl.Instance.language;
		
	}

	void SaveLanguage () {
		
		GlobalControl.Instance.language = language;

	}

	public void Spanish () {
		GlobalControl.Instance.language = 0;
	}

	public void English () {
		GlobalControl.Instance.language = 1;
	}

}
