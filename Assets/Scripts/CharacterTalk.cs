using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterTalk : MonoBehaviour {

	int textNum;
	public string[] alltext;
	public string[] allNames;
	public string nextScene;
	Text talkText;
	public Sprite bgSprite;
	public Sprite[] p1Sprite;
	public Sprite[] p2Sprite;
	Image bg;
	Image p1;
	Image p2;

	void Start(){
		textNum = 0;
		bg = GetComponent<Image>();
		p1 = transform.Find("P1").GetComponent<Image>();
		p2 = transform.Find("P2").GetComponent<Image>();
		talkText = transform.Find("TalkText").transform.GetComponentInChildren<Text>();
	}

	void Update(){
		talkText.text = allNames[textNum] + ": " + alltext[textNum];
		bg.sprite = bgSprite;
		p1.sprite = p1Sprite[textNum];
		p2.sprite = p2Sprite[textNum];
	}

	public void Advance(){
		textNum++;
		if(textNum >= alltext.Length){
			LoadLevel();
		}
	}

	void LoadLevel(){
		textNum = 0;
		if(nextScene != "No"){
			SceneManager.LoadScene(nextScene);
		}
	}
}
