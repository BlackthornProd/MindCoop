using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

	public GameObject bubble;
	private bool hasBubble = false;
	public Animator bubbleAnim;

	public GameObject[] slides;
	public int currentSlide = 0;

	void Update(){

		if(Input.GetKeyDown(KeyCode.Return) && hasBubble == false){
			
			bubble.SetActive(true);
			bubbleAnim.SetTrigger("In");
			hasBubble = true;
		} else if(Input.GetKeyDown(KeyCode.Return) && hasBubble == true){
			StartCoroutine(Dissapear());
		}

		if(Input.GetKeyDown(KeyCode.X)){
			if(currentSlide == slides.Length -1){
				bubbleAnim.SetTrigger("Change");
				currentSlide = 0;
			} else {
				bubbleAnim.SetTrigger("Change");
				currentSlide++;
			}
		} else if(Input.GetKeyDown(KeyCode.W)){
			if(currentSlide == 0){
				bubbleAnim.SetTrigger("Change");
				currentSlide = slides.Length -1;
			} else {
				bubbleAnim.SetTrigger("Change");
				currentSlide--;
			}
		}

		for (int i = 0; i < slides.Length; i++) {
			if(i == currentSlide){
				slides[i].SetActive(true);
			} else {
				slides[i].SetActive(false);
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
