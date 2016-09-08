using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public Sprite[] spriteExplain, spriteDraw;
	public Sprite spriteGetIt;

	public Image imageExplain, imageDraw, imageCancel;
	private int i = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		imageDraw.sprite = spriteDraw[i];
		imageExplain.sprite = spriteExplain[i];
	
	}

	public void ButtonNext() {
		if(i < spriteDraw.Length) {
			i++;

			if(i == spriteDraw.Length - 1)
				imageCancel.sprite = spriteGetIt;

			if(i == spriteDraw.Length) {
				i = 0;
			}
		}
	}

	public void ButtonPrevious() {
		if(i > 0) {
			i--;
		} else if(i <= 0) {
			i = spriteDraw.Length - 1;
		}
		
	}
}
