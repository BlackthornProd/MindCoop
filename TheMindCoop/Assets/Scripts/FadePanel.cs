using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanel : MonoBehaviour {

	private Animator anim;

	void Awake(){

		anim = GetComponent<Animator>();
	}

	void Start(){


		if(anim != null){
			anim.SetTrigger("FadeOut");
		}

	}



	public void FadeIn(){
		if(anim != null){
			anim.SetTrigger("FadeIn");
		}

	}
}
