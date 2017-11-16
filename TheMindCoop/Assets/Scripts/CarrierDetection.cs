using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierDetection : MonoBehaviour {

	private GameObject[] targets;
	private Animator anim;

	void Start(){

		anim = GetComponent<Animator>();
		
		if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}
	}

	void Update(){

		if(Vector2.Distance(transform.position, targets[0].transform.position) < 15){
			anim.SetBool("AngryIdle", true);
		} else if(Vector2.Distance(transform.position, targets[1].transform.position)  < 15){
			anim.SetBool("AngryIdle", true);
		} else {
			anim.SetBool("AngryIdle", false);
		}
	}
}
