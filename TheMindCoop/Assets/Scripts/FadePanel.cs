using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanel : MonoBehaviour {

	private Animator anim;

	void Start(){

		anim = GetComponent<Animator>();
		anim.SetTrigger("FadeOut");
	}



	public void FadeIn(){

		anim.SetTrigger("FadeIn");
	}
}
