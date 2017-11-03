using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckLevel : MonoBehaviour {

	public GameObject pt_Spanish, pt_English, actions, energy, pause, btn_continue, btn_restart, btn_exit;
	public GameObject w_great, w_withJust, w_actions, w_wygd, w_restart, w_exit;
	public GameObject l_great, l_withJust, l_actions, l_wygd, l_restart, l_exit;

	public Sprite actions_spa, actions_eng, energy_spa, energy_eng, pause_spa, pause_eng, continue_spa, continue_eng,
	restart_spa, restart_eng, exit_spa, exit_eng;

	public Sprite w_great_spa, w_great_eng, w_withJust_spa, w_withJust_eng, w_actions_spa, w_actions_eng, w_wygd_spa,
	w_wygd_eng, w_restart_spa, w_restart_eng, w_exit_spa, w_exit_eng;

	public Sprite l_great_spa, l_great_eng, l_withJust_spa, l_withJust_eng, l_actions_spa, l_actions_eng, l_wygd_spa,
	l_wygd_eng, l_restart_spa, l_restart_eng, l_exit_spa, l_exit_eng;

	public bool pressed = false;

	GlobalControl gc;

	// Use this for initialization
	void Start () { 

		gc = GameObject.Find("GlobalObject").GetComponent<GlobalControl>();

	}
	
	// Update is called once per frame
	void Update () {

		if(gc.language == 1) {
			
			EnglishSprites();

		} else if (gc.language == 0) {

			SpanishSprites();

		}
			
	}

	void SpanishSprites () {

		// Tutorial
		if(!pressed) {
			pt_Spanish.SetActive(true);
		} else {
			pt_Spanish.SetActive(false);
		}

		pt_English.SetActive(false);

		// HUD
		actions.GetComponent<Image>().sprite = actions_spa;
		energy.GetComponent<Image>().sprite = energy_spa;

		// Pause
		pause.GetComponent<Image>().sprite = pause_spa;
		btn_continue.GetComponent<Image>().sprite = continue_spa;
		btn_restart.GetComponent<Image>().sprite = restart_spa;
		btn_exit.GetComponent<Image>().sprite = exit_spa;

		// Winner
		w_great.GetComponent<Image>().sprite = w_great_spa;
		w_withJust.GetComponent<Image>().sprite = w_withJust_spa;
		w_actions.GetComponent<Image>().sprite = w_actions_spa;
		w_wygd.GetComponent<Image>().sprite = w_wygd_spa;
		w_restart.GetComponent<Image>().sprite = w_restart_spa;
		w_exit.GetComponent<Image>().sprite = w_exit_spa;

		// Looser
		l_great.GetComponent<Image>().sprite = l_great_spa;
		l_withJust.GetComponent<Image>().sprite = l_withJust_spa;
		l_actions.GetComponent<Image>().sprite = l_actions_spa;
		l_wygd.GetComponent<Image>().sprite = l_wygd_spa;
		l_restart.GetComponent<Image>().sprite = l_restart_spa;
		l_exit.GetComponent<Image>().sprite = l_exit_spa;

		
	}

	void EnglishSprites () {

		// Tutorial
		if(!pressed) {
			pt_English.SetActive(true);
		} else {
			pt_English.SetActive(false);
		}

		pt_Spanish.SetActive(false);

		// HUD
		actions.GetComponent<Image>().sprite = actions_eng;
		energy.GetComponent<Image>().sprite = energy_eng;

		// Pause
		pause.GetComponent<Image>().sprite = pause_eng;
		btn_continue.GetComponent<Image>().sprite = continue_eng;
		btn_restart.GetComponent<Image>().sprite = restart_eng;
		btn_exit.GetComponent<Image>().sprite = exit_eng;

		// Winner
		w_great.GetComponent<Image>().sprite = w_great_eng;
		w_withJust.GetComponent<Image>().sprite = w_withJust_eng;
		w_actions.GetComponent<Image>().sprite = w_actions_eng;
		w_wygd.GetComponent<Image>().sprite = w_wygd_eng;
		w_restart.GetComponent<Image>().sprite = w_restart_eng;
		w_exit.GetComponent<Image>().sprite = w_exit_eng;

		// Looser
		l_great.GetComponent<Image>().sprite = l_great_eng;
		l_withJust.GetComponent<Image>().sprite = l_withJust_eng;
		l_actions.GetComponent<Image>().sprite = l_actions_eng;
		l_wygd.GetComponent<Image>().sprite = l_wygd_eng;
		l_restart.GetComponent<Image>().sprite = l_restart_eng;
		l_exit.GetComponent<Image>().sprite = l_exit_eng;

		
	}

	public void DeactivatePanel () {
		pressed = true;
	}

}
