using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

	public GameObject bubble;
	private bool hasBubble = false;
	public Animator bubbleAnim;

	public GameObject[] slides;
	public GameObject[] slidesFriends;
	public int currentSlide = 0;
	private bool enemiesTab = true;

	void Start(){
		enemiesTab = true;
	}

	void Update(){

		if(Input.GetKeyDown(KeyCode.Return) && hasBubble == false){
			
			bubble.SetActive(true);
			bubbleAnim.SetTrigger("In");
			hasBubble = true;
		} else if(Input.GetKeyDown(KeyCode.Return) && hasBubble == true){
			StartCoroutine(Dissapear());
		}

		if(Input.GetKeyDown(KeyCode.X) && enemiesTab == true){
			if(currentSlide == slides.Length -1){
				bubbleAnim.SetTrigger("Change");
				currentSlide = 0;
			} else {
				bubbleAnim.SetTrigger("Change");
				currentSlide++;
			}
		} else if(Input.GetKeyDown(KeyCode.W)&& enemiesTab == true){
			if(currentSlide == 0){
				bubbleAnim.SetTrigger("Change");
				currentSlide = slides.Length -1;
			} else {
				bubbleAnim.SetTrigger("Change");
				currentSlide--;
			}
		}

		if(Input.GetKeyDown(KeyCode.X) && enemiesTab == false){
			if(currentSlide == slidesFriends.Length -1){
				bubbleAnim.SetTrigger("Change");
				currentSlide = 0;
			} else {
				bubbleAnim.SetTrigger("Change");
				currentSlide++;
			}
		} else if(Input.GetKeyDown(KeyCode.W)&& enemiesTab == false){
			if(currentSlide == 0){
				bubbleAnim.SetTrigger("Change");
				currentSlide = slidesFriends.Length -1;
			} else {
				bubbleAnim.SetTrigger("Change");
				currentSlide--;
			}
		}

		if(Input.GetKeyDown(KeyCode.C) && enemiesTab == true){
			bubbleAnim.SetTrigger("Change");
			enemiesTab = false;
			currentSlide = 0;
			for (int i = 0; i < slides.Length; i++) {
				slides[i].SetActive(false);
			}
		} else if(Input.GetKeyDown(KeyCode.C) && enemiesTab == false){
			enemiesTab = true;
			currentSlide = 0;
			for (int i = 0; i < slidesFriends.Length; i++) {
				slidesFriends[i].SetActive(false);
			}
		}

		for (int i = 0; i < slides.Length; i++) {
			if(i == currentSlide && enemiesTab == true){
				slides[i].SetActive(true);
			} else if(i != currentSlide && enemiesTab == true){
				slides[i].SetActive(false);
			}
		}

		for (int i = 0; i < slidesFriends.Length; i++) {

			if(i == currentSlide && enemiesTab == false){
				slidesFriends[i].SetActive(true);
			} else if(i != currentSlide && enemiesTab == false){
				slidesFriends[i].SetActive(false);
			}
		}
	}

	IEnumerator Dissapear(){
		bubbleAnim.SetTrigger("Out");
		yield return new WaitForSeconds(0.25f);
		bubble.SetActive(false);
		hasBubble = false;
	}

}
