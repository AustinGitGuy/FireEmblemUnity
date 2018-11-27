using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveChapters : MonoBehaviour {

	public int curChapter;

	bool stopMovement;

	GameObject mainCamera;

	void Start(){
		mainCamera = GameObject.Find("Main Camera");
		mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
		mainCamera.transform.SetParent(this.transform);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Q) && !stopMovement){
			GameObject newChapter = GameObject.Find("Chapter" + (curChapter + 1));
			if(newChapter != null){
				curChapter++;
				transform.position = new Vector3(newChapter.transform.position.x, newChapter.transform.position.y, -2);
				mainCamera.transform.position = new Vector3(newChapter.transform.position.x, newChapter.transform.position.y, -10);
			}
		}
		if(Input.GetKeyDown(KeyCode.E) && !stopMovement){
			GameObject newChapter = GameObject.Find("Chapter" + (curChapter - 1));
			if(newChapter != null){
				curChapter--;
				transform.position = new Vector3(newChapter.transform.position.x, newChapter.transform.position.y, -2);
				mainCamera.transform.position = new Vector3(newChapter.transform.position.x, newChapter.transform.position.y, -10);
			}
		}
		if(Input.GetKeyDown(KeyCode.F) && !stopMovement){
			GameObject curChapObj = GameObject.Find("Chapter" + curChapter);
			if(curChapObj.GetComponent<ChapterData>().EnemyHere){
				gameObject.transform.DetachChildren();
				GameObject.Find("GodObject").GetComponent<GUIManager>().prepMenu.SetActive(true);
				SceneManager.LoadScene("Chapter" + curChapter);
			}
		}
		if(Input.GetKeyDown(KeyCode.R) && !stopMovement){
			GameObject curChapObj = GameObject.Find("Chapter" + curChapter);
			if(curChapObj.GetComponent<ChapterData>().ShopHere){
				GameObject.Find("GodObject").GetComponent<GUIManager>().merchant.SetActive(true);
				GameObject.Find("GodObject").GetComponent<GUIManager>().caravan.SetActive(true);
				GameObject.Find("BuyMenu").GetComponent<ShopManager>().items = curChapObj.GetComponent<ChapterData>().forSale;
				stopMovement = true;
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			GameObject.Find("GodObject").GetComponent<GUIManager>().merchant.SetActive(false);
			GameObject.Find("GodObject").GetComponent<GUIManager>().caravan.SetActive(false);
			stopMovement = false;
		}
	}
}
