using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTuft : MonoBehaviour {

	private Animator anim;

	void Start(){

		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag != "Grass"){
			anim = GetComponent<Animator>();
			anim.SetTrigger("Enter");	
		}


	}
}
