using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	private FadePanel fadePanel;
	public GameObject panel;

	void Start(){

		fadePanel = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<FadePanel>();
		Invoke("SetFalse", 0.5f);
	}

	public void Restart(){
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn(){
		panel.SetActive(true);
		fadePanel.FadeIn();
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Level1");
	}

	void SetFalse(){

		panel.SetActive(false);
	}
}
