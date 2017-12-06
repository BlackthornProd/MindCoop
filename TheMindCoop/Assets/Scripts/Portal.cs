using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {


	private GameMaster gm;
	private FadePanel fadePanel;

	void Start(){
		fadePanel = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<FadePanel>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	
	}

	void Update(){

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			Debug.Log(gm.fire);
			StartCoroutine(LoadScene());
		}
	}

	IEnumerator LoadScene(){
		fadePanel.FadeIn();
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
